using System.Collections.Generic;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Combination
{
    /// <summary>
    /// HighCard is a combination, based on the ICombination interface, that 
    /// will give the player with the highest card the win.
    /// </summary>
    public class HighCard : ICombination
    {
        #region Public Methods

        /// <summary>
        /// All Players can have high card, so it always returns true.
        /// </summary>
        /// <param name="player">Given Player for combination.</param>
        /// <returns>True, as cards can always have a high card.</returns>
        public bool HasCombination(IPlayer player)
        {
            return true;
        }

        /// <summary>
        /// Find the highest Hand of the given List of IPlayers. Return the
        /// winner in a List of IPlayers. If there is a tie, return multiple 
        /// players.
        /// </summary>
        /// <param name="players">List of Players to search through.</param>
        /// <returns>List of Players with highest card.</returns>
        public List<IPlayer> FindHighestHand(List<IPlayer> players)
        {
            var highCard = CardNumber.NotAssigned;
            var highPlayer = new List<IPlayer>();

            // For each player...
            foreach (var player in players)
            {
                //...get the highest card
                var playerHighCard = player.Hand.FindHighCard();

                // ...If they are equal to current highest, add to list.
                if (playerHighCard.Number == highCard && !highPlayer.Contains(player))
                    highPlayer.Add(player);

                // ...if greater then former highest, make sole winner.
                if (playerHighCard.Number > highCard)
                {
                    highCard = playerHighCard.Number;
                    highPlayer = new List<IPlayer>() {player};
                }
            }

            return highPlayer;
        }

        #endregion
    }
}