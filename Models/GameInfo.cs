using System.Collections.Generic;

namespace BattleshipGoogleCloud.Models
{
    public class GameInfo
    {
        public List<PlayerInfo> Players { get; set; }
        public int BattleFieldWidth { get; set; }
        public int BattleFieldHeight { get; set; }
        
    }
}