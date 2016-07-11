using System.Collections.Generic;
using Poker.PokerSolver.Card;

namespace Poker.PokerSolver.Hand
{
    public interface IHand
    {
        bool RemoveCard(ICard card);

        void InsertCard(int position, ICard card);
        void AddCard(ICard card);

        bool HasCard(ICard card);

        bool IsCard(int position, ICard card);

        List<ICard> GetHand();

        bool IsEmpty();
        bool IsFull();

        int Count { get; }
        int MaxSize { get; }

        ICard FindHighCard();
    }
}