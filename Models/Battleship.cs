using System.Runtime.Serialization;

namespace BattleshipGoogleCloud.Models
{
    [DataContract]
    public class Battleship : Ship
    {
        public Battleship(string fleetName)
            : base(fleetName)
        {
        }

        public override int Length => 4;

        public override int MaximumPendingOrders => 2;

        public override bool CanPerformRecon => false;
    }
}
