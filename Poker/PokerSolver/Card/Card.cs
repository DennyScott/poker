using System;

namespace Poker.PokerSolver.Card
{
    /// <summary>
    /// Card Node based on the ICard Interface. Contains a given Suit and Number. 
    /// These Numbers and Suits are formed by Enums.
    /// </summary>
    public class Card : ICard
    {
        #region Instance Variables

        private const string IncorrectArgument = "String was not formatted properly for Card";

        #endregion

        #region Properties

        public CardNumber Number { get; }
        public CardSuit Suit { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="number">Given number of the card</param>
        /// <param name="suit">Given suit of the card</param>
        public Card(CardNumber number, CardSuit suit)
        {
            Number = number;
            Suit = suit;
        }

        /// <summary>
        /// Constructor using string parameters. This requires
        /// parsing string data into enums. Format of "4H".
        /// </summary>
        /// <param name="cardValue">string of data in format "4H"</param>
        public Card(string cardValue)
        {
            //If cards are not of allowable length, throw exception
            if (cardValue.Length != 2 && cardValue.Length != 3)
            {
                throw new ArgumentException(IncorrectArgument);
            }

            var lastCharacterPosition = cardValue.Length - 1;

            //Collect Number and Suit
            Number = ParseStringToCardNumber(cardValue.Substring(0, lastCharacterPosition));
            Suit = ParseCharacterToSuit(cardValue[lastCharacterPosition].ToString());

            //If either of these values are not assigned, meaning we couldn't determine
            //the values, throw an exception.
            if (Number == CardNumber.NotAssigned || Suit == CardSuit.NotAssigned)
                throw new ArgumentException(IncorrectArgument);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Parse a string into a related Enum. The format expected is
        /// a single character, relating to:
        /// 
        /// H = Hearts
        /// D = Diamonds
        /// C = Clubs
        /// S = Spades
        /// 
        /// </summary>
        /// <param name="charSuit">Suit string to parse</param>
        /// <returns>CardSuit of suit, or Not Assigned</returns>
        private CardSuit ParseCharacterToSuit(string charSuit)
        {
            CardSuit suit;

            switch (charSuit.ToUpper())
            {
                case "H":
                    suit = CardSuit.Hearts;
                    break;
                case "D":
                    suit = CardSuit.Diamonds;
                    break;
                case "S":
                    suit = CardSuit.Spades;
                    break;
                case "C":
                    suit = CardSuit.Clubs;
                    break;
                default:
                    suit = CardSuit.NotAssigned;
                    break;
            }

            return suit;
        }

        /// <summary>
        /// Parse a string Value into a CardNumber enum. If the value is not found,
        /// return the unassigned value. We expect the values if the given strings
        /// 
        /// A = Ace
        /// 2 = 2
        /// 3 = 3
        /// 4 = 4
        /// 5 = 5
        /// 6 = 6
        /// 7 = 7
        /// 8 = 8
        /// 9 = 9
        /// 10 = 10
        /// J = Jack
        /// Q = Queen
        /// K = King
        /// 
        /// </summary>
        /// <param name="num">Number to parse for CardNumber</param>
        /// <returns>CardNumber enum of found type, or unassigned</returns>
        private CardNumber ParseStringToCardNumber(string num)
        {
            CardNumber number;
            switch (num)
            {
                case "A":
                    number = CardNumber.Ace;
                    break;
                case "2":
                    number = CardNumber.Two;
                    break;
                case "3":
                    number = CardNumber.Three;
                    break;
                case "4":
                    number = CardNumber.Four;
                    break;
                case "5":
                    number = CardNumber.Five;
                    break;
                case "6":
                    number = CardNumber.Six;
                    break;
                case "7":
                    number = CardNumber.Seven;
                    break;
                case "8":
                    number = CardNumber.Eight;
                    break;
                case "9":
                    number = CardNumber.Nine;
                    break;
                case "10":
                    number = CardNumber.Ten;
                    break;
                case "J":
                    number = CardNumber.Jack;
                    break;
                case "Q":
                    number = CardNumber.Queen;
                    break;
                case "K":
                    number = CardNumber.King;
                    break;
                default:
                    number = CardNumber.NotAssigned;
                    break;
            }

            return number;
        }

        #endregion
    }
}