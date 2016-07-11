using System.Collections.Generic;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Hand;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Combination
{
    public class ThreeOfAKind : ICombination
    {
        public bool HasCombination(IPlayer player)
        {
            return FindThreeOfAKind(player.Hand.GetHand()) != CardNumber.NotAssigned;
        }

        public List<IPlayer> FindHighestHand(List<IPlayer> players)
        {
            var highestNumber = CardNumber.NotAssigned;
            var topPlayers = new List<IPlayer>();

            foreach (var player in players)
            {
                var cardNum = FindThreeOfAKind(player.Hand.GetHand());
                if (cardNum > highestNumber)
                {
                    highestNumber = cardNum;
                    topPlayers = new List<IPlayer>() {player};
                }
            }

            return topPlayers;
        }

        private CardNumber FindThreeOfAKind(List<ICard> hand)
        {
            for (var i = 0; i < hand.Count; i++)
            {
                var pairs = new List<CardNumber>();
                for (var j = 0; j < hand.Count; j++)
                {
                    if (i == j || hand[i].Number != hand[j].Number) continue;

                    if (pairs.Contains(hand[i].Number))
                    {
                        return hand[i].Number;
                    }

                    pairs.Add(hand[i].Number);
                }
            }

            return CardNumber.NotAssigned;
        }
    }
}