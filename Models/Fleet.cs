using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace BattleshipGoogleCloud.Models
{
    [DataContract()]
    public class Fleet
    {
        /// <summary>
        /// Size of length and width of the region that a fleet takes up
        /// </summary>
        public const int REGION_SIZE = 20;

        public Fleet(string name)
        {
            Name = name;
            AircraftCarrier = new AircraftCarrier(Name);
            Battleship = new Battleship(Name);
            Destroyer = new Destroyer(Name);
            PTBoat = new PTBoat(Name);
            Submarine = new Submarine(Name);
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int RegionX { get; set; }

        [DataMember]
        public int RegionY { get; set; }

        [DataMember]
        public AircraftCarrier AircraftCarrier { get; set; }

        [DataMember]
        public Battleship Battleship { get; set; }

        [DataMember]
        public Destroyer Destroyer { get; set; }

        [DataMember]
        public PTBoat PTBoat { get; set; }

        [DataMember]
        public Submarine Submarine { get; set; }

        public List<Ship> GetShips()
        {
            List<Ship> ships = new List<Ship>
            {
                AircraftCarrier,
                Battleship,
                Destroyer,
                PTBoat,
                Submarine
            };
            return ships;
        }

        public Ship GetShipByID(string id)
        {
            foreach (Ship s in GetShips())
            {
                if (s.ID == id)
                {
                    return s;
                }
            }
            return null;
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(Environment.NewLine);
            foreach (Ship s in GetShips())
            {
                sb.Append(s.ToString());
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public bool IsSunk()
        {
            foreach (Ship s in GetShips())
            {
                if (!s.IsSunk())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
