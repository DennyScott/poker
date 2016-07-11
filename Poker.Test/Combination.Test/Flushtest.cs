using System.Collections.Generic;
using NUnit.Framework;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Combination;
using Poker.PokerSolver.Player;

namespace Poker.Test.Combination.Test
{
    [TestFixture]
    public class FlushTest
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
            player.Hand.AddCard(new Card("6D"));

            playerTwo = new Player("two");
            playerTwo.Hand.AddCard(new Card("2D"));
            playerTwo.Hand.AddCard(new Card("2C"));
            playerTwo.Hand.AddCard(new Card("4D"));
            playerTwo.Hand.AddCard(new Card("4C"));
            playerTwo.Hand.AddCard(new Card("6H"));

            playerThree = new Player("three");
            playerThree.Hand.AddCard(new Card("3C"));
            playerThree.Hand.AddCard(new Card("4C"));
            playerThree.Hand.AddCard(new Card("5C"));
            playerThree.Hand.AddCard(new Card("6C"));
            playerThree.Hand.AddCard(new Card("7C"));

            playerFour = new Player("four");
            playerFour.Hand.AddCard(new Card("8D"));
            playerFour.Hand.AddCard(new Card("9D"));
            playerFour.Hand.AddCard(new Card("10D"));
            playerFour.Hand.AddCard(new Card("JD"));
            playerFour.Hand.AddCard(new Card("QD"));

            _combo = new Flush();
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
        public void ComparingTwoFlushShouldHaveHighCardWin()
        {
            var gameOne = new List<IPlayer>() {player, playerFour};
            var expectedWinner = new List<IPlayer>() {playerFour};

            Assert.AreEqual(expectedWinner, _combo.FindHighestHand(gameOne));
        }
    }
}