using System;
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

        public void InsertCard(int position, ICard card)
        {
            if (CanAddCard(card))
            {
                _hand.Insert(position, card);
            }
        }

        public void AddCard(ICard card)
        {
            if (CanAddCard(card))
            {
                _hand.Add(card);
            }
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

        public List<ICard> GetHand()
        {
            return new List<ICard>(_hand);
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public bool IsFull()
        {
            return Count >= MaxSize;
        }

        public ICard FindHighCard()
        {
            if (IsEmpty()) return null;
            var topCard = _hand[0];

            foreach (var card in _hand)
            {
                if (card.Number > topCard.Number)
                {
                    topCard = card;
                }
            }

            return topCard;
        }

        public int Count => _hand.Count;

        private bool CanAddCard(ICard card)
        {
            return !HasCard(card) && !IsFull();
        }
    }
}