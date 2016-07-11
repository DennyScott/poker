using Poker.PokerSolver.Hand;

namespace Poker.PokerSolver.Player
{
    public interface IPlayer
    {
        string Name { get; }
        IHand Hand { get; }
    }
}