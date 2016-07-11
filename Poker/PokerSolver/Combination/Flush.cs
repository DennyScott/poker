using System.Collections.Generic;
using System.Linq;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Combination
{
    public class Flush : ICombination
    {
        public bool HasCombination(IPlayer player)
        {
            var hand = player.Hand.GetHand();
            return hand.All(t => hand.All(t1 => t.Suit == t1.Suit));
        }

        public List<IPlayer> FindHighestHand(List<IPlayer> players)
        {
            var highCard = CardNumber.NotAssigned;
            var highPlayer = new List<IPlayer>();

            foreach (var player in players)
            {
                var playerHighCard = player.Hand.FindHighCard();

                if (playerHighCard.Number == highCard && !highPlayer.Contains(player))
                {
                    highPlayer.Add(player);
                }

                if (playerHighCard.Number > highCard)
                {
                    highCard = playerHighCard.Number;
                    highPlayer = new List<IPlayer>() {player};
                }
            }

            return highPlayer;
        }
    }
}