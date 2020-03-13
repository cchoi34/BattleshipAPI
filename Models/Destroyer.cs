using System.Runtime.Serialization;

namespace BattleshipGoogleCloud.Models
{
    [DataContract]
    public sealed class Destroyer : Ship
    {

        public Destroyer(string fleetName)
            : base(fleetName)
        {
        }

        public override int Length => 4;

        public override int MaximumPendingOrders => 1;

        public override bool CanPerformRecon => false;
    }
}
