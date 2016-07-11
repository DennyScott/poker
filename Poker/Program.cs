using System;
using System.Collections.Generic;
using Poker.PokerSolver.Card;
using Poker.PokerSolver.Game;
using Poker.PokerSolver.Player;

namespace Poker
{
    /// <summary>
    /// Program Runner
    /// </summary>
    public class Program
    {
        const string startInstructions =
            "\nWelcome. Please select from the instructions below by inputing the number, and pressing enter:" +
            "\n 1. Enter Player" +
            "\n 2. Run Game" +
            "\n 3. Restart" +
            "\n 4. Quit";

        const string enterPlayerInstructions =
            "\nPlease enter the player in the format of \"Joe, 4H, 5H, 6H, 7H, 8H\", without quotes, followed by enter.";

        const string runGameText = "\nThe winner(s) are: ";

        const string quitText = "\nThanks for playing!";

        public static List<IPlayer> Players = new List<IPlayer>();
        public static IGame Game = new Game();

        /// <summary>
        /// Main Runner
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var option = 0;

            // Ask for user input, if input= 4, stop.
            while (option != 4)
            {
                //Display Initial Instructions
                Console.WriteLine(startInstructions);

                try
                {
                    //Get Instruction from user
                    option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            //enter player name
                            var playerData = CollectPlayerName();
                            EnterPlayer(playerData);
                            break;
                        case 2:
                            //Run the game
                            RunGame();
                            break;
                        case 3: 
                            //Reset the Game
                            ResetGame();
                            break;
                        case 4:
                            //Quit
                            Console.WriteLine(quitText);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Collect the Player name. This assumed the following format:
        /// 
        /// Name, Card, Card, Card, Card, Card
        /// Joe, 2H, 3H, 4H, 5H, 9H
        /// </summary>
        /// <returns></returns>
        public static string CollectPlayerName()
        {
            Console.WriteLine(enterPlayerInstructions);
            return Console.ReadLine();
        }

        /// <summary>
        /// Parse the player name and cards from input, and add each card
        /// to a new player. Once complete, add player to list of current players.
        /// </summary>
        /// <param name="playerData">Data to clean, and make new player from.</param>
        public static void EnterPlayer(string playerData)
        {
            var splitData = playerData.Split(',');

            var player = new Player(splitData[0].Trim());

            for (var i = 1; i < splitData.Length; i++)
            {
                player.Hand.AddCard(new Card(splitData[i].Trim()));
            }

            Players.Add(player);
        }

        /// <summary>
        /// Reset the current game by clearing the list of players.
        /// </summary>
        public static void ResetGame()
        {
            Players.Clear();
        }

        /// <summary>
        /// Run the Game.  This will call the PokerSolver library and
        /// determine the winner(s).
        /// </summary>
        public static void RunGame()
        {
            var winners = Game.Play(Players);
            Console.Write(runGameText);

            //Display each winner
            foreach (var player in winners)
            {
                Console.Write(player.Name);
            }
            Console.Write("\n\n");
        }
    }
}