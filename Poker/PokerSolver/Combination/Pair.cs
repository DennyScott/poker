using System;
using System.Collections.Generic;
using System.Linq;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Hand;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Combination
{
    public class Pair : ICombination
    {
        public bool HasCombination(IPlayer player)
        {
            var hand = player.Hand.GetHand();

            //Go through hand, then iterate through the hand again, if two numbers match
            //that aren't the same card, return true.
            return hand.Where((t1, i) => hand.Where((t, j) => i != j).Any(t => t1.Number == t.Number)).Any();
        }

        public List<IPlayer> FindHighestHand(List<IPlayer> players)
        {
            var highestNumber = CardNumber.NotAssigned;
            var topPlayers = new List<IPlayer>();

            foreach (var player in players)
            {
                var hand = player.Hand.GetHand();

                for (var i = 0; i < hand.Count; i++)
                {
                    for (var j = 0; j < hand.Count; j++)
                    {
                        if (hand[i].Number != hand[j].Number || i == j) continue;
;
                        if (hand[i].Number > highestNumber)
                        {
                            highestNumber = hand[i].Number;
                            topPlayers = new List<IPlayer> {player};
                        } else if (hand[i].Number == highestNumber)
                        {
                            if(!topPlayers.Contains(player))
                                topPlayers.Add(player);
                        }
                    }
                }
            }

            return topPlayers;
        }
    }
}