using System.Collections.Generic;
using Poker.PokerSolver.Card;

namespace Poker.PokerSolver.Hand
{
    public class Hand : IHand
    {
        private List<ICard> _hand;

        public Hand(int maxSize = 5)
        {
            _hand = new List<ICard>();
            MaxSize = maxSize;
        }

        public int MaxSize { get; }
        public object Clone()
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveCard(int position)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveCard(ICard card)
        {
            return _hand.Remove(card);
        }

        public bool RemoveCard(CardSuit suit, CardNumber number)
        {
            throw new System.NotImplementedException();
        }

        public void AddCard(int position, ICard card)
        {
            throw new System.NotImplementedException();
        }

        public void AddCard(ICard card)
        {
            _hand.Add(card);
        }

        public bool HasCard(ICard card)
        {
            return _hand.Contains(card);
        }

        public bool HasCard(CardSuit suit, CardNumber number)
        {
            throw new System.NotImplementedException();
        }

        public bool IsCard(int position, ICard card)
        {
            return card.Equals(_hand[position]);
        }

        public ICard GetCard(int position)
        {
            throw new System.NotImplementedException();
        }

        public bool IsEmpty()
        {
            return _hand.Count == 0;
        }

        public int Count => _hand.Count;
    }
}