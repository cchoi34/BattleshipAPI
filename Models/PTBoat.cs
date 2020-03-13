using System.Runtime.Serialization;

namespace BattleshipGoogleCloud.Models
{
    [DataContract]
    public sealed class PTBoat : Ship
    {
        public PTBoat(string fleetName)
            : base(fleetName)
        {
        }

        public override int Length => 2;

        public override int MaximumPendingOrders => 1;

        public override bool CanPerformRecon => false;
    }
}
