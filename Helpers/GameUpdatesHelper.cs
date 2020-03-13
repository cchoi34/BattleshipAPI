using BattleshipGoogleCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleshipGoogleCloud.Helpers
{
    public class GameUpdatesHelper
    {
        private readonly int _currentHitX;
        private readonly int _currentHitY;

        public GameUpdatesHelper(Order order)
        {
            _currentHitX = order.Coordinate.X;
            _currentHitY = order.Coordinate.Y;
        }

        public List<PlayerInfo> UpdatePlayerInfo(List<PlayerInfo> playerInfo)
        {
            foreach (var player in playerInfo)
            {
                if (IsXInOwnArea(player) && IsYInOwnArea(player))
                {
                    var shipsSunk = player.ShipsSunk + 1;
                    var fleetSunk = shipsSunk == 5 ? true : false;

                    player.ShipsSunk = shipsSunk;
                    player.FleetSunk = fleetSunk;
                }
            }

            return playerInfo;
        }

        private bool IsXInOwnArea(PlayerInfo player)
        {
            if (_currentHitX >= player.StartCoordinate.X && _currentHitX < player.EndCoordinate.X)
            {
                return true;
            }
            return false;
        }

        private bool IsYInOwnArea(PlayerInfo player)
        {
            if (_currentHitY >= player.StartCoordinate.Y && _currentHitY < player.EndCoordinate.Y)
            {
                return true;
            }
            return false;
        }
    }
}