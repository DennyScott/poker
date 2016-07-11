using System;
using System.Collections.Generic;
using Poker.PokerSolver.Card;

namespace Poker.PokerSolver.Hand
{
    public interface IHand
    {
        bool RemoveCard(int position);
        bool RemoveCard(ICard card);
        bool RemoveCard(CardSuit suit, CardNumber number);

        void InsertCard(int position, ICard card);
        void AddCard(ICard card);

        bool HasCard(ICard card);
        bool HasCard(CardSuit suit, CardNumber number);

        bool IsCard(int position, ICard card);

        ICard GetCard(int position);
        List<ICard> GetHand();

        bool IsEmpty();
        bool IsFull();

        int Count { get; }
        int MaxSize { get; }

        ICard FindHighCard();
    }
}