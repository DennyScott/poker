using System;
using NUnit.Framework;
using Poker.PokerSolver.Card;

namespace Poker.Test.PokerSolver.Test.Card.Test
{
    [TestFixture]
    public class CardTest
    {
        private ICard _card;
        private CardNumber _number;
        private CardSuit _suit;

        [SetUp]
        public void Init()
        {
            _number = CardNumber.Two;
            _suit = CardSuit.Hearts;
            _card = new Poker.PokerSolver.Card.Card(_number, _suit);
        }

        [Test]
        public void DoesCreatingCardStoreNumberFromEnum()
        {
            //Assert
            Assert.AreEqual(_number, _card.Number);
        }

        [Test]
        public void DoesCreatingCardStoreSuitFromEnum()
        {
            //Assert
            Assert.AreEqual(_suit, _card.Suit);
        }

        [Test]
        public void DoesCreatingCardWithStringStoreNumber()
        {
            //Arrange
            const string cardValue = "5D";

            //Act
            _card = new Poker.PokerSolver.Card.Card(cardValue);

            //Assert
            Assert.AreEqual(CardNumber.Five, _card.Number);
        }

        [Test]
        public void DoesCreatingCardWithStringStoreEnum()
        {
            //Arrange
            const string cardValue = "4C";

            //Act
            _card = new Poker.PokerSolver.Card.Card(cardValue);

            //Assert
            Assert.AreEqual(CardSuit.Clubs, _card.Suit);
        }

        [Test]
        public void DoesCreatingCardWithIncorrectStringThrowException()
        {
            //Arrange
            const string cardValue = "$$";

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                new Poker.PokerSolver.Card.Card(cardValue);
            });
        }
    }
}