using System.Collections.Generic;
using NUnit.Framework;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Combination;
using Poker.PokerSolver.Player;

namespace Poker.Test.Combination.Test
{
    public class HighCardTest
    {
        private IPlayer player, playerTwo, playerThree;
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

            _combo = new HighCard();
        }

        [Test]
        public void ComparingTwoHighCardShouldHaveHighestWin()
        {
            var gameOne = new List<IPlayer>() { player, playerThree };
            var expectedWinner = new List<IPlayer>() { playerThree };

            Assert.AreEqual(expectedWinner, _combo.FindHighestHand(gameOne));
        }

        [Test]
        public void ComparingTwoHighCardWithSameHighShouldHaveTie()
        {
            var gameOne = new List<IPlayer>() { player, playerTwo };

            Assert.AreEqual(gameOne, _combo.FindHighestHand(gameOne));
        }
    }

}