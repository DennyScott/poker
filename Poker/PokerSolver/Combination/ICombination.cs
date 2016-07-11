using System.Collections.Generic;
using Poker.PokerSolver.Hand;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Combination
{
    public interface ICombination
    {
        bool HasCombination(IPlayer player);
        List<IPlayer> FindHighestHand(List<IPlayer> players);
    }
}