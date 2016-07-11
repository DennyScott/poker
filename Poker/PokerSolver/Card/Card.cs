using System;

namespace Poker.PokerSolver.Card
{
    public class Card : ICard
    {
        private const string IncorrectArgument = "String was not formatted properly for Card";

        public Card(CardNumber number, CardSuit suit)
        {
            Number = number;
            Suit = suit;
        }

        public Card(string cardValue)
        {
            if (cardValue.Length != 2 && cardValue.Length != 3)
            {
                throw new ArgumentException(IncorrectArgument);
            }

            var lastCharacterPosition = cardValue.Length - 1;

            Number = ParseStringToCardNumber(cardValue.Substring(0, lastCharacterPosition));
            Suit = ParseCharacterToSuit(cardValue[lastCharacterPosition]);

            if (Number == CardNumber.NotAssigned || Suit == CardSuit.NotAssigned)
                throw new ArgumentException(IncorrectArgument);
        }

        public CardNumber Number { get; }
        public CardSuit Suit { get; }

        private CardSuit ParseCharacterToSuit(char charSuit)
        {
            CardSuit suit;

            switch (charSuit)
            {
                case 'H':
                    suit = CardSuit.Hearts;
                    break;
                case 'D':
                    suit = CardSuit.Diamonds;
                    break;
                case 'S':
                    suit = CardSuit.Spades;
                    break;
                case 'C':
                    suit = CardSuit.Clubs;
                    break;
                default:
                    suit = CardSuit.NotAssigned;
                    break;
            }

            return suit;
        }

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
    }
}