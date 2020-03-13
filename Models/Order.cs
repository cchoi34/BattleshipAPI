using System.Runtime.Serialization;

namespace BattleshipGoogleCloud.Models
{
    [DataContract]
    public class Order
    {
        /// <summary>
        /// They type of order
        /// </summary>
        [DataMember]
        public OrderType Type { get; set; }

        /// <summary>
        /// The coordinate that relates to the order
        /// </summary>
        [DataMember]
        public Coordinate Coordinate { get; set; } = new Coordinate(-1, -1);

        /// <summary>
        /// Data for the order - use to specify the message being sent
        /// </summary>
        [DataMember]
        public string Data { get; set; }
 
        /// <summary>
        /// Result of an executed order
        /// </summary>
        [DataMember]
        public OrderResult Result { get; set; } = OrderResult.OrderNotExecuted;

        [DataMember]
        public string PlayerTargeted { get; set; }

        public override string ToString()
        {
            return string.Format("Order -- Type: {0}, Coordinate: {1}, Data: {2}, Result:{3}", new object[] { this.Type.ToString(), this.Coordinate.ToString(), this.Data, this.Result });
        }
    
    }


    public enum OrderType
    {
        /// <summary>
        /// Attacks a given location
        /// </summary>
        Attack,
        /// <summary>
        /// Peforms recon in a 3x3 square starting in the top-left coordinate specified
        /// </summary>
        Recon,
        /// <summary>
        /// Broadcasts a message to all teams
        /// </summary>
        BroadcastMessage
    }

    /// <summary>
    /// Results of executing an order
    /// </summary>
    public enum OrderResult
    {
        IllegalOrder,
        IllegalOrderShipSunk,
        OrderNotExecuted,
        Miss,
        ShipHit,
        ShipSunk,
        ShipFound,
        ShipNotFound,
        MessageSent
    }
}
