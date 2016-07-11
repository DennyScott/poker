# Poker Solver

## Overview
This is a rudimentary poker solver. Important pieces to note here
* Project is built in Visual Studio 2015, using C#, Nuget, and NUnit.
* The Poker Solver library is within the PokerSolver Folder. The program.cs is just the base runner 
to demo the library.
* All tests are written in a seperate project in the solution, called Poker.Test.
* Tests are written in NUnit, and added using Nuget.
* The program.cs is rather simple, and meant to just demo simple user input and output.
* You can right click the tests to run, or use the NUnit Adapter 3 in Visual Studio Extensions. Occasionally, you will need to restart Visual Studio after download.

## Assumptions
* Assumed that if players tied on a combination (pair), the player with the higher number combo won. 
* You cannot override a previous player with the same name. You would need to reset the game.
* Assumed that if players tied on one combination, and had equal numbers, that we would pass through other combinations until a winner was found. Finally, we use the high card to find a winner. If those are equal, then it is a tie.
