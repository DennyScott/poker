using System;
using Poker.PokerSolver.Card;

namespace Poker.PokerSolver.Hand
{
    public interface IHand : ICloneable
    {
        bool RemoveCard(int position);
        bool RemoveCard(ICard card);
        bool RemoveCard(CardSuit suit, CardNumber number);

        void AddCard(int position, ICard card);
        void AddCard(ICard card);

        bool HasCard(ICard card);
        bool HasCard(CardSuit suit, CardNumber number);

        bool IsCard(int position, ICard card);

        ICard GetCard(int position);

        bool IsEmpty();
        int Count { get; }
        int MaxSize { get; }
    }
}