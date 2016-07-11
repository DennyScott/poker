namespace Poker.PokerSolver.Player
{
    /// <summary>
    /// Players contain a Name and a Hand.
    /// </summary>
    public class Player : IPlayer
    {
        #region Properties

        public string Name { get; }
        public Hand.IHand Hand { get; }

        #endregion

        #region Cosntructor

        public Player(string name)
        {
            Name = name;
            Hand = new Hand.Hand();
        }

        #endregion
    }
}