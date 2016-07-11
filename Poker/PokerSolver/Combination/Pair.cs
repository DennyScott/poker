using System.Collections.Generic;
using System.Linq;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Combination
{
    /// <summary>
    /// Find a Pair Combination, based on the ICombination interface. This allows
    /// user to see if a player has a pair, and who has the highest pair. A Pair
    /// is a hand that has two CardNumbers that are equal.
    /// </summary>
    public class Pair : ICombination
    {
        #region Public Methods

        /// <summary>
        /// Check if a given player has two CardNumbers in their hand that are equal.
        /// </summary>
        /// <param name="player">Player, whose hand we are checking</param>
        /// <returns>True if player has combination, else false.</returns>
        public bool HasCombination(IPlayer player)
        {
            var hand = player.Hand.GetHand();

            //Go through hand, then iterate through the hand again, if two numbers match
            //that aren't the same card, return true.
            return hand.Where((t1, i) => hand.Where((t, j) => i != j).Any(t => t1.Number == t.Number)).Any();
        }

        /// <summary>
        /// For a given set of Players, return the players with the highest pair value.
        /// If a one player has a pair of 2's, and another player has a pair of threes, the 
        /// latter player is the winner.
        /// 
        /// If multiple players are tied, return all tied players.
        /// </summary>
        /// <param name="players">Players with combination to tally score of</param>
        /// <returns>List of Iplayers with Highest Score</returns>
        public List<IPlayer> FindHighestHand(List<IPlayer> players)
        {
            var highestNumber = CardNumber.NotAssigned;
            var topPlayers = new List<IPlayer>();

            //For each player in the list of players...
            foreach (var player in players)
            {
                var hand = player.Hand.GetHand();

                // ...Iterate through each card...
                for (var i = 0; i < hand.Count; i++)
                {
                    // ...and Iterate through each card again...
                    for (var j = 0; j < hand.Count; j++)
                    {
                        //... if we are on the same card, or not a pair, skip this round
                        if (hand[i].Number != hand[j].Number || i == j) continue;

                        // if number is higher then highest, save winner
                        if (hand[i].Number > highestNumber)
                        {
                            highestNumber = hand[i].Number;
                            topPlayers = new List<IPlayer> {player};
                        }

                        //If score is equal to current winner, add player to list
                        if (hand[i].Number == highestNumber)
                        {
                            if (!topPlayers.Contains(player))
                                topPlayers.Add(player);
                        }
                    }
                }
            }

            return topPlayers;
        }

        #endregion
    }
}