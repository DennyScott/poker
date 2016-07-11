using System.Collections.Generic;
using Poker.PokerSolver.Card;

namespace Poker.PokerSolver.Hand
{
    /// <summary>
    /// Hand is an implementation of the IHand interface. It is a loose 
    /// data structure wrapped around a Generic List of ICards.
    /// </summary>
    public class Hand : IHand
    {
        #region Instance Variables

        private readonly List<ICard> _hand;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize">Max Size of Hand. Default 5</param>
        public Hand(int maxSize = 5)
        {
            _hand = new List<ICard>();
            MaxSize = maxSize;
        }

        #endregion

        #region Properties

        public int MaxSize { get; }

        public int Count => _hand.Count;

        #endregion

        #region Public Methods

        /// <summary>
        /// Remove given card from your hand. If card is removed, return
        /// true. If not, return false;
        /// </summary>
        /// <param name="card">Given Card to Remove from Hand</param>
        /// <returns>True if card is removed, else false.</returns>
        public bool RemoveCard(ICard card)
        {
            return _hand.Remove(card);
        }

        /// <summary>
        /// Insert a card into hand at a specified position. If card already
        /// exists in hand, or hand is full, the card will not be added to their
        /// hand.
        /// </summary>
        /// <param name="position">Position to add card to</param>
        /// <param name="card">Card to be added to hand.</param>
        public void InsertCard(int position, ICard card)
        {
            if (CanAddCard(card))
            {
                _hand.Insert(position, card);
            }
        }

        /// <summary>
        /// Add Card to last spot in list. If card already exists or hand is full,
        /// the card will not be added to their hand.
        /// </summary>
        /// <param name="card">Card to be added to hand.</param>
        public void AddCard(ICard card)
        {
            if (CanAddCard(card))
            {
                _hand.Add(card);
            }
        }

        /// <summary>
        /// Does hand contain the given card. True if card exists, else false.
        /// </summary>
        /// <param name="card">Card to check that exists in hand</param>
        /// <returns>If card exists in hand, true, else false</returns>
        public bool HasCard(ICard card)
        {
            return _hand.Contains(card);
        }

        /// <summary>
        /// Check if given position is hand is the passed card. If it is, return
        /// true, else false.
        /// </summary>
        /// <param name="position">position in the hand</param>
        /// <param name="card">Card to check if exists</param>
        /// <returns>True if given position has card, else false.</returns>
        public bool IsCard(int position, ICard card)
        {
            return card.Equals(_hand[position]);
        }

        /// <summary>
        /// Get the hand, which is a list of ICards. This will be a clone of the
        /// hand.
        /// </summary>
        /// <returns>Clone of Hand</returns>
        public List<ICard> GetHand()
        {
            return new List<ICard>(_hand);
        }

        /// <summary>
        /// Is the current hand empty. If the size of the list is 0,
        /// the hand is empty.
        /// </summary>
        /// <returns>True if hand is empty, else false.</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// Is the current hand full. This is compared against the maxSize
        /// property. If it reaches max size, the hand is considered full.
        /// </summary>
        /// <returns>True if hand is full, else false.</returns>
        public bool IsFull()
        {
            return Count >= MaxSize;
        }

        /// <summary>
        /// Find the highest numbered card in current hand. If
        /// the hand is empty, return null.
        /// </summary>
        /// <returns>Found Highest Number card, or null for empty</returns>
        public ICard FindHighCard()
        {
            //No cards in hand, return null
            if (IsEmpty()) return null;
            var topCard = _hand[0];

            // For each card in hand...
            foreach (var card in _hand)
            {
                // ... find highest card in hand.
                if (card.Number > topCard.Number)
                {
                    topCard = card;
                }
            }

            return topCard;
        }

        /// <summary>
        /// Can we add the given card to hand. This will test by checking
        /// if the current hand is already full, and if the card already exists 
        /// in the users hand.
        /// </summary>
        /// <param name="card"> Card to check</param>
        /// <returns>If allowed to add, true, else false</returns>
        public bool CanAddCard(ICard card)
        {
            return !HasCard(card) && !IsFull();
        }

        #endregion
    }
}