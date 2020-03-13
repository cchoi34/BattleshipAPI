using System;
using System.Runtime.Serialization;

namespace BattleshipGoogleCloud.Models
{
    /// <summary>
    /// Describes a location on the gameboard
    /// </summary>
    [DataContract]
    public class Coordinate : IEquatable<Coordinate>
    {
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }

        public Coordinate()
        {

        }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override int GetHashCode()
        {
            string temp = X.ToString() + "," + Y.ToString();
            return temp.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", X.ToString(), Y.ToString());
        }

        #region IEquatable<Coordinate> Members

        public bool Equals(Coordinate other)
        {
            return (this.X == other.X && this.Y == other.Y);
        }

        #endregion
    }

}
