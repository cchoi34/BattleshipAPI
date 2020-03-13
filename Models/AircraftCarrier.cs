using System.Runtime.Serialization;

namespace BattleshipGoogleCloud.Models
{
    [DataContract]
    public sealed class AircraftCarrier : Ship
    {
        public AircraftCarrier(string fleetName)
            : base(fleetName)
        {
        }

        public override int Length => 5;

        public override int MaximumPendingOrders => 2;

        public override bool CanPerformRecon => true;
    }
}
