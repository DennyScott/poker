using System.Collections.Generic;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Combination
{
    /// <summary>
    /// Find a three of a kind combination, based on the ICombination interface.
    /// This allows users to see if a player has a three of a kind, and who has 
    /// the highest three of a kind. A three of a kind is when a hand has three
    /// CardNumbers that are equal. i.e. 3H, 3D, 3C, 5D, 8H
    /// </summary>
    public class ThreeOfAKind : ICombination
    {
        #region Public Methods

        /// <summary>
        /// Check if a given player has three CardNumbers in their hand that are
        /// equal.
        /// </summary>
        /// <param name="player">Player to check had of</param>
        /// <returns>True if player has combo, else false.</returns>
        public bool HasCombination(IPlayer player)
        {
            return FindThreeOfAKind(player.Hand.GetHand()) != CardNumber.NotAssigned;
        }

        /// <summary>
        /// Find the Highest Three of a Kind, for a given list of players.
        /// The highest is the three of a kind that has the highest number.
        /// Note this can only return one victor, despite being a list.
        /// </summary>
        /// <param name="players">List of players to check high value</param>
        /// <returns>Player with the highest card value.</returns>
        public List<IPlayer> FindHighestHand(List<IPlayer> players)
        {
            var highestNumber = CardNumber.NotAssigned;
            var topPlayers = new List<IPlayer>();

            //For each plyaer...
            foreach (var player in players)
            {
                //...Get three of a kind
                var cardNum = FindThreeOfAKind(player.Hand.GetHand());

                //...If largest three of a kind, player is winner.
                if (cardNum > highestNumber)
                {
                    highestNumber = cardNum;
                    topPlayers = new List<IPlayer>() {player};
                }
            }

            return topPlayers;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Find three of a kind in game, and return the found
        /// CardNumber. If none is found, return CardNumber.NotAssigned.
        /// </summary>
        /// <param name="hand">Hand to search for three of a kind with</param>
        /// <returns></returns>
        private CardNumber FindThreeOfAKind(List<ICard> hand)
        {
            // For each card in players hand...
            for (var i = 0; i < hand.Count; i++)
            {
                var pairs = new List<CardNumber>();
                // ..iterate through each other card
                for (var j = 0; j < hand.Count; j++)
                {
                    // ..If cards are the same, or not equal, skip this round
                    if (i == j || hand[i].Number != hand[j].Number) continue;

                    //...If card is paired, and we've seen the pair before...
                    if (pairs.Contains(hand[i].Number))
                    {
                        // ...return the three of a kind
                        return hand[i].Number;
                    }

                    // If this is the first pair found, add to list.
                    pairs.Add(hand[i].Number);
                }
            }

            return CardNumber.NotAssigned;
        }

        #endregion
    }
}