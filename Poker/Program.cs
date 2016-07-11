using System;
using System.Collections.Generic;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Game;
using Poker.PokerSolver.Player;

namespace Poker
{
    class Program
    {
        const string startInstructions =
            "Welcome. Please select from the instructions below by inputing the number, and pressing enter:" +
            "\n 1. Enter Player" +
            "\n 2. Run Game" +
            "\n 3. Restart" +
            "\n 4. Quit";

        const string enterPlayerInstructions =
            "Please enter the player in the format of \"Joe, 4H, 5H, 6H, 7H, 8H\", without quotes, followed by enter.";

        const string runGameText = "The winner(s) are: ";

        const string quitText = "Thanks for playing!";

        private static List<IPlayer> _players;
        private static IGame _game;

        static void Main(string[] args)
        {
            var option = 0;
            _players = new List<IPlayer>();
            _game = new Game();

            while (option != 4)
            {
                Console.WriteLine(startInstructions);

                try
                {
                    option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            EnterPlayer();
                            break;
                        case 2:
                            RunGame();
                            break;
                        case 3: 
                            ResetGame();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void EnterPlayer()
        {
            Console.WriteLine(enterPlayerInstructions);
            var playerData = Console.ReadLine();

            var splitData = playerData.Split(',');

            var player = new Player(splitData[0].Trim());

            for (var i = 1; i < splitData.Length; i++)
            {
                player.Hand.AddCard(new Card(splitData[i].Trim()));
            }

            _players.Add(player);
        }

        private static void ResetGame()
        {
            _players.Clear();
        }

        private static void RunGame()
        {
            var winners = _game.Play(_players);
            Console.Write(runGameText);

            foreach (var player in winners)
            {
                Console.Write(player.Name);
            }
            Console.Write("\n\n");
        }
    }
}