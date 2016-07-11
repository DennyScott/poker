using NUnit.Framework;
using Poker.PokerSolver.Card;

namespace Poker.Test.PokerSolver.Test.Hand.Test
{
    [TestFixture]
    public class HandTest
    {
        private Poker.PokerSolver.Hand.Hand _hand;
        private ICard _cardOne;
        private ICard _cardTwo;

        [SetUp]
        public void Init()
        {
            _cardOne = new Poker.PokerSolver.Card.Card("3D");
            _cardTwo = new Poker.PokerSolver.Card.Card("4C");
            _hand = new Poker.PokerSolver.Hand.Hand();
        }

        [Test]
        public void HandShouldStartEmpty()
        {
            //Assert
            Assert.IsTrue(_hand.IsEmpty());
        }

        [Test]
        public void HandShouldStartAtCountZero()
        {
            //Assert
            Assert.AreEqual(0, _hand.Count);
        }

        [Test]
        public void AddingACardShouldIncreaseTheCount()
        {
            //Act
            _hand.AddCard(_cardOne);

            //Assert
            Assert.AreEqual(1, _hand.Count);
        }

        [Test]
        public void AddingACardShouldAddCardToList()
        {
            //Act
            _hand.AddCard(_cardOne);

            //Assert
            Assert.IsFalse(_hand.IsEmpty());
        }

        [Test]
        public void RemovingTheOnlyCardShouldResetEmpty()
        {
            //Arrange
            _hand.AddCard(_cardOne);

            //Act
            _hand.RemoveCard(_cardOne);

            //Assert
            Assert.IsTrue(_hand.IsEmpty());
        }

        [Test]
        public void RemovingACardRemoveItemFromListShouldReduceCount()
        {
            //Arrange
            _hand.AddCard(_cardOne);

            //Act
            _hand.RemoveCard(_cardOne);

            //Assert
            Assert.AreEqual(0, _hand.Count);
        }

        [Test]
        public void RemovingNonExistantCardShouldRunSuccessfully()
        {
            //Arrange
            _hand.AddCard(_cardOne);

            //Act
            _hand.RemoveCard(_cardTwo);

            //Assert
            Assert.IsFalse(_hand.IsEmpty());
        }

        [Test]
        public void AddingACardToAPositionShouldMoveOtherCardsForward()
        {
            //Arrange
            _hand.AddCard(_cardOne);

            //Act
            _hand.InsertCard(0, _cardTwo);

            //Assert
            Assert.IsTrue(_hand.IsCard(0, _cardTwo));
        }

        [Test]
        public void CheckingCardShouldBeAddedCard()
        {
            //Arrange
            _hand.AddCard(_cardOne);

            //Assert
            Assert.IsTrue(_hand.IsCard(0, _cardOne));
        }

        [Test]
        public void HasCardShouldReturnFalseIfCardIsNotInHand()
        {
            //Arrange
            _hand.AddCard(_cardOne);

            //Assert
            Assert.IsFalse(_hand.HasCard(_cardTwo));
        }

        [Test]
        public void HasCardShouldReturnTrueIfCardIsInHand()
        {
            //Arrange
            _hand.AddCard(_cardOne);
            _hand.AddCard(_cardTwo);

            //Assert
            Assert.IsTrue(_hand.HasCard(_cardOne));
        }

        [Test]
        public void AddingACardAlreadyInTheHandShouldDoNothing()
        {
            //Arrange
            _hand.AddCard(_cardOne);

            //Act
            _hand.AddCard(_cardOne);

            //Assert
            Assert.AreEqual(1, _hand.Count);
        }

        [Test]
        public void HandReachingMaxSizeShouldBeFull()
        {
            //Arrange
            FillHand();

            //Assert
            Assert.IsTrue(_hand.IsFull());
        }

        [Test]
        public void AddingMoreThenMaxCardsShouldDoNothing()
        {
            //Arrage
            FillHand();

            //Act
            _hand.AddCard(new Poker.PokerSolver.Card.Card("10C"));

            //Assert
            Assert.AreEqual(_hand.MaxSize, _hand.Count);
        }

        [Test]
        public void FindHighCardWillReturnTheCardWithTheHighestNumber()
        {
            //Arrange
            FillHand();

            //Act
            var topCard = _hand.FindHighCard();

            //Assert
            Assert.AreEqual(CardNumber.Nine, topCard.Number);
        }

        public void FillHand()
        {
            _hand.AddCard(_cardOne);
            _hand.AddCard(_cardTwo);
            _hand.AddCard(new Poker.PokerSolver.Card.Card("7C"));
            _hand.AddCard(new Poker.PokerSolver.Card.Card("8C"));
            _hand.AddCard(new Poker.PokerSolver.Card.Card("9C"));
        }
    }
}
