using System.Collections.Generic;
using System.Linq;
using Poker.PokerSolver.Combination;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Game
{
    public class Game : IGame
    {
        private readonly ICombination[] _combos;
        private List<IPlayer> playersInGame;

        public Game()
        {
            _combos = new ICombination[3];
            _combos[0] = new Flush();
            _combos[1] = new ThreeOfAKind();
            _combos[2] = new Pair();
        }
        
        public List<IPlayer> Play(List<IPlayer> players)
        {
            playersInGame = players;
            return FindTopPlayer();
        }

        private List<IPlayer> FindTopPlayer()
        {
            var remainingPlayers = new List<IPlayer>(playersInGame);

            foreach (var combination in _combos)
            {
                remainingPlayers = FindPlayersWithCombo(remainingPlayers, combination);
                if (remainingPlayers.Count == 0)
                {
                    remainingPlayers = new List<IPlayer>(playersInGame);
                    continue;
                }

                remainingPlayers = FindHighestCombo(remainingPlayers, combination);
                if (remainingPlayers.Count == 1)
                {
                    return remainingPlayers;
                }
            }

            return FindHighCard(remainingPlayers);

        }

        private List<IPlayer> FindPlayersWithCombo(List<IPlayer> players, ICombination combination)
        {
            var playersWithCombo = new List<IPlayer>();

            playersWithCombo.AddRange(players.Where(combination.HasCombination));
            return playersWithCombo;
        }

        private List<IPlayer> FindHighestCombo(List<IPlayer> players, ICombination combination)
        {
            return combination.FindHighestHand(players);
        }

        private List<IPlayer> FindHighCard(List<IPlayer> players)
        {
            foreach (var player in players)
            {
                
            }

            return players;
        }
    }
}