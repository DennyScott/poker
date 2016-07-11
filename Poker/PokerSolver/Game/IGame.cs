using System.Collections.Generic;
using Poker.PokerSolver.Player;

namespace Poker.PokerSolver.Game
{
    public interface IGame
    {
        List<IPlayer> Play(List<IPlayer> players);
    }
}