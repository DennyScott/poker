namespace Poker.PokerSolver.Card
{
    public interface ICard
    {
        CardNumber Number { get; }
        CardSuit Suit { get; }
    }
}