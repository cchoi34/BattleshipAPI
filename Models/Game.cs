using System.Collections.Generic;

namespace BattleshipGoogleCloud.Models
{
    public class Game
    {
        public Game()
        {
            Orders = new List<Order>();
        }

        public GameInfo GameInfo { get; set; }
        public List<Order> Orders { get; set; }        
    }
}
