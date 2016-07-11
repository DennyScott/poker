using System.Collections.Generic;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Combination
{
    public class HighCard : ICombination
    {
        public bool HasCombination(IPlayer player)
        {
            return true;
        }

        public List<IPlayer> FindHighestHand(List<IPlayer> players)
        {
            var highCard = CardNumber.NotAssigned;
            var highPlayer = new List<IPlayer>();

            foreach (var player in players)
            {
                var playerHighCard = player.Hand.FindHighCard();

                if(playerHighCard.Number == highCard && !highPlayer.Contains(player))
                    highPlayer.Add(player);

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