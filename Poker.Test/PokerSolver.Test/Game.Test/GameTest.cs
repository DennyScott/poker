using System.Collections.Generic;
using NUnit.Framework;
using Poker.PokerSolver.Game;
using Poker.PokerSolver.Player;

namespace Poker.Test.PokerSolver.Test.Game.Test
{
    [TestFixture]
    public class GameTest
    {
        private Poker.PokerSolver.Player.IPlayer _playerOne;
        private Poker.PokerSolver.Player.IPlayer _playerTwo;
        private Poker.PokerSolver.Player.IPlayer _playerThree;
        private Poker.PokerSolver.Player.IPlayer _playerFour;
        private Poker.PokerSolver.Player.IPlayer _playerFive;

        private static List<IPlayer> _gameOnePlayers;
        private List<IPlayer> _gameTwoPlayers;
        private List<IPlayer> _gameThreePlayers;
        private List<IPlayer> _gameFourPlayers;

        private IGame _game;

        [SetUp]
        public void Init()
        {
            _playerOne = new Poker.PokerSolver.Player.Player("one");
            _playerOne.Hand.AddCard(new Poker.PokerSolver.Card.Card("2D"));
            _playerOne.Hand.AddCard(new Poker.PokerSolver.Card.Card("2H"));
            _playerOne.Hand.AddCard(new Poker.PokerSolver.Card.Card("4S"));
            _playerOne.Hand.AddCard(new Poker.PokerSolver.Card.Card("5S"));
            _playerOne.Hand.AddCard(new Poker.PokerSolver.Card.Card("8H"));

            _playerTwo = new Poker.PokerSolver.Player.Player("two");
            _playerTwo.Hand.AddCard(new Poker.PokerSolver.Card.Card("3D"));
            _playerTwo.Hand.AddCard(new Poker.PokerSolver.Card.Card("3H"));
            _playerTwo.Hand.AddCard(new Poker.PokerSolver.Card.Card("4D"));
            _playerTwo.Hand.AddCard(new Poker.PokerSolver.Card.Card("5D"));
            _playerTwo.Hand.AddCard(new Poker.PokerSolver.Card.Card("10H"));

            _playerThree = new Poker.PokerSolver.Player.Player("three");
            _playerThree.Hand.AddCard(new Poker.PokerSolver.Card.Card("4D"));
            _playerThree.Hand.AddCard(new Poker.PokerSolver.Card.Card("4H"));
            _playerThree.Hand.AddCard(new Poker.PokerSolver.Card.Card("4S"));
            _playerThree.Hand.AddCard(new Poker.PokerSolver.Card.Card("6S"));
            _playerThree.Hand.AddCard(new Poker.PokerSolver.Card.Card("JH"));

            _playerFour = new Poker.PokerSolver.Player.Player("four");
            _playerFour.Hand.AddCard(new Poker.PokerSolver.Card.Card("AD"));
            _playerFour.Hand.AddCard(new Poker.PokerSolver.Card.Card("JD"));
            _playerFour.Hand.AddCard(new Poker.PokerSolver.Card.Card("QD"));
            _playerFour.Hand.AddCard(new Poker.PokerSolver.Card.Card("KD"));
            _playerFour.Hand.AddCard(new Poker.PokerSolver.Card.Card("10D"));

            _playerFive = new Poker.PokerSolver.Player.Player("five");
            _playerFive.Hand.AddCard(new Poker.PokerSolver.Card.Card("9D"));
            _playerFive.Hand.AddCard(new Poker.PokerSolver.Card.Card("JD"));
            _playerFive.Hand.AddCard(new Poker.PokerSolver.Card.Card("QD"));
            _playerFive.Hand.AddCard(new Poker.PokerSolver.Card.Card("KD"));
            _playerFive.Hand.AddCard(new Poker.PokerSolver.Card.Card("10D"));

            _gameOnePlayers = new List<IPlayer>() {_playerOne, _playerTwo, _playerThree, _playerFour};
            _gameTwoPlayers = new List<IPlayer>() { _playerOne, _playerTwo};
            _gameThreePlayers = new List<IPlayer>() { _playerTwo, _playerThree};
            _gameFourPlayers = new List<IPlayer>() {_playerFour, _playerFive};

            _game = new Poker.PokerSolver.Game.Game();
        }

        [Test]
        public void PlayingGameFlushShouldBeTopWinner()
        {
           var calculatedWinner = _game.Play(_gameOnePlayers);

            Assert.AreEqual(_playerFour.Name, calculatedWinner[0].Name);
        }

        [Test]
        public void PlayingGameHighCardShouldBeTopWinnerAfterPairTie()
        {
            var calculatedWinner = _game.Play(_gameTwoPlayers);

            Assert.AreEqual(_playerTwo.Name, calculatedWinner[0].Name);
        }

        [Test]
        public void PlayeingGameThreeOfAKindShouldBeatPair()
        {
            var calculatedWinner = _game.Play(_gameThreePlayers);

            Assert.AreEqual(_playerThree.Name, calculatedWinner[0].Name);
        }

        [Test]
        public void PlayingGameHighCouldShouldBeWinner()
        {
            var calculateWinner = _game.Play(_gameFourPlayers);

            Assert.AreEqual(_playerFour.Name, calculateWinner[0].Name);
        }
    }
}
