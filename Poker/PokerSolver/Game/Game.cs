using System.Collections.Generic;
using System.Linq;
using Poker.PokerSolver.Combination;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Game
{
    /// <summary>
    /// Main Game Logic. This is used to run the game, and passes the needed
    /// cards through the desired logic. This class, in genreal, runs Poker Solver.
    /// </summary>
    public class Game : IGame
    {
        #region Instance Variables

        private readonly ICombination[] _combos;
        private List<IPlayer> _playersInGame;

        #endregion

        #region Constructor

        public Game()
        {
            //Create array of possible hand combinations. The order
            //they are inserted dictates the "better" combo. First in the
            //list is the best combo.
            _combos = new ICombination[4];
            _combos[0] = new Flush();
            _combos[1] = new ThreeOfAKind();
            _combos[2] = new Pair();
            _combos[3] = new HighCard();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Run a round of the game. This will take a list of players,
        /// and return a list of players who won the round.
        /// </summary>
        /// <param name="players">Players who are playing in the round</param>
        /// <returns>Players who won the round.</returns>
        public List<IPlayer> Play(List<IPlayer> players)
        {
            _playersInGame = players;
            return FindTopPlayer();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Find the top player(s) from a given set of players.
        /// </summary>
        /// <returns>A list of the winners</returns>
        private List<IPlayer> FindTopPlayer()
        {
            //New list of players from the players in the game.
            var remainingPlayers = new List<IPlayer>(_playersInGame);

            // For each combination allowed
            foreach (var combination in _combos)
            {
                //... find the remaining players that has the given combo...
                var comboPlayers = FindPlayersWithCombo(remainingPlayers, combination);

                // .. if no players are found, this combination will not be used, and we can go to next
                if (comboPlayers.Count == 0)
                {
                    continue;
                }

                //Below here means we found players with the given combo, so we place them
                //into the remaining players
                remainingPlayers = comboPlayers;

                //Find the player with the highest combo score
                remainingPlayers = FindHighestCombo(remainingPlayers, combination);

                //If only one player remains, return the player,
                //if not check the next combination
                if (remainingPlayers.Count == 1)
                {
                    return remainingPlayers;
                }
            }

            // return the found players.
            return remainingPlayers;
        }

        /// <summary>
        /// Find Players with a Given Combination. This will Find all players that 
        /// have the passed combination, and return them in a List of IPlayers.
        /// </summary>
        /// <param name="players">Players to check for combination</param>
        /// <param name="combination">Combination to search for</param>
        /// <returns>List of IPlayers with the passed combination</returns>
        private List<IPlayer> FindPlayersWithCombo(List<IPlayer> players, ICombination combination)
        {
            var playersWithCombo = new List<IPlayer>();

            //Find all Players that Combination.HasCombination is true
            playersWithCombo.AddRange(players.Where(combination.HasCombination));
            return playersWithCombo;
        }

        /// <summary>
        /// Find players with the Highest Combination score for a given combination.
        /// The player with the highest score is returned in a List of Players. In case
        /// of a tie, multiple players are returned.
        /// </summary>
        /// <param name="players">Players to compare for combination score</param>
        /// <param name="combination">Combination to check score against</param>
        /// <returns>Player(s) with the highest score</returns>
        private List<IPlayer> FindHighestCombo(List<IPlayer> players, ICombination combination)
        {
            return combination.FindHighestHand(players);
        }

        #endregion
    }
}