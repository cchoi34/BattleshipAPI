using System.Runtime.Serialization;

namespace BattleshipGoogleCloud.Models
{
    [DataContract]
    public sealed class Submarine : Ship
    {
        public Submarine(string fleetName)
            : base(fleetName)
        {
        }

        public override int Length => 3;

        public override int MaximumPendingOrders => 1;

        public override bool CanPerformRecon => true;
    }
}
