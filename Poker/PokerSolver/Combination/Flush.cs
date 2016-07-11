using System.Collections.Generic;
using System.Linq;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Combination
{
    /// <summary>
    /// Flush is based on the ICombination interface. It will
    /// look if a set of Cards has all five matching suits.
    /// 
    /// i.e. 4H, 5H, 7H, 8H, 9H
    /// 
    /// The above example is a flush because all cards have the "Heart" suit.
    /// </summary>
    public class Flush : ICombination
    {
        #region Public Methods

        /// <summary>
        /// Does the current players hand have a flush.
        /// </summary>
        /// <param name="player">Player to check for combination</param>
        /// <returns>True if has combo, else false</returns>
        public bool HasCombination(IPlayer player)
        {
            var hand = player.Hand.GetHand();

            //If all cards have one suit, true, else false.
            return hand.All(t => hand.All(t1 => t.Suit == t1.Suit));
        }

        /// <summary>
        /// Given a List of Players, find the Player with the highest score. 
        /// In a flush, this will be the "highest" card number in the flush.
        /// 
        /// If these are equal for multiple players, they will tie.
        /// </summary>
        /// <param name="players">Players to search hands.</param>
        /// <returns>List of IPlayers with highest score</returns>
        public List<IPlayer> FindHighestHand(List<IPlayer> players)
        {
            var highCard = CardNumber.NotAssigned;
            var highPlayer = new List<IPlayer>();

            //For each player...
            foreach (var player in players)
            {
                // ...get the players highest hand
                var playerHighCard = player.Hand.FindHighCard();

                //If they are equal to the highest found card, add to List of winners
                if (playerHighCard.Number == highCard && !highPlayer.Contains(player))
                {
                    highPlayer.Add(player);
                }

                // If there number is higher the current highest, make them the sole winner
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