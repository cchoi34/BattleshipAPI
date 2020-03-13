namespace BattleshipGoogleCloud.Models
{
    public class Message
    {
        public UpdateType Updatetype { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }

    public enum UpdateType
    {
        FleetSunk,
        PlayerKicked
    }
}