namespace BattleshipGoogleCloud.Models
{
    public class PlayerInfo
    {
        public Coordinate StartCoordinate { get; set; }
        public Coordinate EndCoordinate { get; set; }
        public string PlayerName { get; set; }
        public int ShipsSunk { get; set; }
        public bool FleetSunk { get; set; }
    }
}