namespace Poker.PokerSolver.Player
{
    public class Player : IPlayer
    {
        public string Name { get; private set; }
        public Hand.IHand Hand { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hand = new Hand.Hand();
        }
    }
}
