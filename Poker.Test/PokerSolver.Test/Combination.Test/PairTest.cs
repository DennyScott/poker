using System.Collections.Generic;
using NUnit.Framework;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Combination;
using Poker.PokerSolver.Player;

namespace Poker.Test.Combination.Test
{
    [TestFixture]
    public class PairTest
    {
        private IPlayer player, playerTwo, playerThree, playerFour;
        private ICombination _combo;

        [SetUp]
        public void Init()
        {
            player = new Player("one");
            player.Hand.AddCard(new Card("2D"));
            player.Hand.AddCard(new Card("3D"));
            player.Hand.AddCard(new Card("4D"));
            player.Hand.AddCard(new Card("5D"));
            player.Hand.AddCard(new Card("5H"));

            playerTwo = new Player("two");
            playerTwo.Hand.AddCard(new Card("2D"));
            playerTwo.Hand.AddCard(new Card("3D"));
            playerTwo.Hand.AddCard(new Card("4D"));
            playerTwo.Hand.AddCard(new Card("5D"));
            playerTwo.Hand.AddCard(new Card("6H"));

            playerThree = new Player("three");
            playerThree.Hand.AddCard(new Card("2D"));
            playerThree.Hand.AddCard(new Card("3D"));
            playerThree.Hand.AddCard(new Card("4D"));
            playerThree.Hand.AddCard(new Card("5C"));
            playerThree.Hand.AddCard(new Card("5S"));

            playerFour = new Player("four");
            playerFour.Hand.AddCard(new Card("2D"));
            playerFour.Hand.AddCard(new Card("3D"));
            playerFour.Hand.AddCard(new Card("4D"));
            playerFour.Hand.AddCard(new Card("6C"));
            playerFour.Hand.AddCard(new Card("6S"));

            _combo = new Pair();
        }

        [Test]
        public void HandWithCombinationShouldReturnTrue()
        {
            //Assert
            Assert.IsTrue(_combo.HasCombination(player));
            Assert.IsTrue(_combo.HasCombination(playerThree));
            Assert.IsTrue(_combo.HasCombination(playerFour));
        }

        [Test]
        public void HandWithoutCombinationShouldReturnFalse()
        {
            //Assert
            Assert.IsFalse(_combo.HasCombination(playerTwo));
        }

        [Test]
        public void HighestPairShouldBeReturnedInList()
        {
            //Arrange
            var gameOne = new List<IPlayer>() {player, playerFour};
            var expectedWinnerGameTwo = new List<IPlayer>() {playerFour};

            //Assert
            Assert.AreEqual(expectedWinnerGameTwo, _combo.FindHighestHand(gameOne));
        }

        [Test]
        public void TieWinOnEqualPairShouldReturnBoth()
        {
            //Arrange
            var gameOne = new List<IPlayer>() {player, playerThree};

            //Assert
            Assert.AreEqual(gameOne, _combo.FindHighestHand(gameOne));
        }
    }
}