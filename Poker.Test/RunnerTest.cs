using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Poker.Test
{
    [TestFixture]
    public class RunnerTest
    {
        private string _playerOne = "Jim, 4H, 3H, 2H, 5H, 7H";
        private string _playerTwo = "Al, 4D, 3C, 6H, 7S, 9H";
        private string _playerThree = "Ted, 3H, 3D, 4S, 6C, 8D";
        private string _playerFour = "Sam, 4D, 3D, 2D, 5D, 7D";

        [SetUp]
        public void Init()
        {
            Program.ResetGame();
        }

        [Test]
        public void EnterPlayerShouldAddPlayerToList()
        {
            Program.EnterPlayer(_playerOne);
            Program.EnterPlayer(_playerTwo);

            Assert.AreEqual(2, Program.Players.Count);
            Assert.AreEqual("Jim", Program.Players[0].Name);
            Assert.AreEqual("Al", Program.Players[1].Name);
        }

        [Test]
        public void PlayerWithTheFlushHandShouldWinGame()
        {
            Program.EnterPlayer(_playerOne);
            Program.EnterPlayer(_playerTwo);

            var player = Program.Game.Play(Program.Players);

            Assert.AreEqual("Jim", player[0].Name);
            Assert.AreEqual(1, player.Count);
        }

        [Test]
        public void PlayerWithTheFlushHandTwoShouldWinGame()
        {
            Program.EnterPlayer(_playerOne);
            Program.EnterPlayer(_playerTwo);
            Program.EnterPlayer(_playerThree);

            var player = Program.Game.Play(Program.Players);

            Assert.AreEqual("Jim", player[0].Name);
            Assert.AreEqual(1, player.Count);
        }

        [Test]
        public void PlayerWithTheFlushHandsShouldTieGameWhenEqual()
        {
            Program.EnterPlayer(_playerOne);
            Program.EnterPlayer(_playerFour);
            Program.EnterPlayer(_playerThree);

            var player = Program.Game.Play(Program.Players);

            Assert.AreEqual("Jim", player[0].Name);
            Assert.AreEqual("Sam", Program.Players[1].Name);
            Assert.AreEqual(2, player.Count);
        }
    }
}