using System.Runtime.Serialization;

namespace BattleshipGoogleCloud.Models
{
    [DataContract]
    public abstract class Ship
    {
        public Ship(string fleetName)
        {
            InitializeDamage();
            FleetName = fleetName;
        }

        /// <summary>
        /// current damage
        /// </summary>
        [DataMember]
        public bool[] Damage { get; set; }

        /// <summary>
        /// Name of associated fleet
        /// </summary>
        [DataMember]
        public string FleetName { get; set; }

        /// <summary>
        /// Position of ship relative to the fleet's absolute location on the game board
        /// </summary>
        [DataMember]
        public Coordinate PositionRelative { get; set; } = new Coordinate(0, 0);

        /// <summary>
        /// Position of ship relative to the fleet's absolute location on the game board
        /// </summary>
        [DataMember]
        public Coordinate PositionAbsolute { get; set; } = new Coordinate(0, 0);


        /// <summary>
        /// ID of the ship
        /// </summary>
        /// <remarks>
        /// This is set by the game server during registration
        /// </remarks>
        [DataMember]
        public string ID { get; set; }


        /// <summary>
        /// How the ship is positioned on the game board
        /// </summary>
        [DataMember]
        public ShipOrientation Orientation { get; set; }

        /// <summary>
        /// How many spots this ship takes up on the game board
        /// </summary>
        public abstract int Length { get; }

        protected void InitializeDamage()
        {
            Damage = new bool[this.Length];
        }

        public bool IsSunk()
        {
            for (int d = 0; d < Damage.Length; d++)
            {
                if (!Damage[d])
                {
                    return false;
                }
            }
            return true;
        }



        public override string ToString()
        {
            return string.Format("{0} {1} {2}", new object[] { this.GetType().Name, PositionAbsolute.ToString(), Orientation.ToString() });
        }

        /// <summary>
        /// Executes the order specified if the ship is not sunk
        /// </summary>
        /// <param name="order"></param>
        public void ExecuteOrder(Order order)
        {
            if (IsSunk())
            {
                return;
            }
        }

        /// <summary>
        /// How many concurrent orders can be pending (sent to game)
        /// </summary>
        public abstract int MaximumPendingOrders { get; }

        /// <summary>
        /// Indicates whether Ship can execute Recon orders
        /// </summary>
        public abstract bool CanPerformRecon { get; }
    }


    public enum ShipOrientation
    {
        Vertical,
        Horizontal
    }
}
