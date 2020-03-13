using BattleshipGoogleCloud.Models;
using System.Linq;

namespace BattleshipGoogleCloud.Extensions
{
    public static class GameExtensions
    {
        private static string _playerName = "Choiboi";

        public static Order GetNextOrder(this Game game)
        {
            var playerToTarget = game.GameInfo.Players.FirstOrDefault(player => player.PlayerName != _playerName && !player.FleetSunk);

            if (playerToTarget == null)
            {
                return new Order { Coordinate = new Coordinate(), Type = OrderType.Attack };
            }

            var lastOrder = game.Orders?.LastOrDefault();

            if (lastOrder == null || lastOrder.PlayerTargeted != playerToTarget.PlayerName)
            {
                return new Order { Coordinate = playerToTarget.StartCoordinate, PlayerTargeted = playerToTarget.PlayerName, Type = OrderType.Attack };
            }

            var xStart = playerToTarget.StartCoordinate.X;
            var xLimit = playerToTarget.EndCoordinate.X;

            var currentX = lastOrder.Coordinate.X + 1;
            var currentY = lastOrder.Coordinate.Y;

            if (currentX > xLimit)
            {
                currentX = xStart;
                currentY += 1;
            }

            var attackCoordinate = new Coordinate(currentX, currentY);

            return new Order { Coordinate = attackCoordinate, PlayerTargeted = playerToTarget.PlayerName, Type = OrderType.Attack };
        }

        public static Order GetNextRecon(this Game game)
        {
            var playerToRecon = game.GameInfo.Players.FirstOrDefault(player => player.PlayerName != _playerName && !player.FleetSunk);

            if (playerToRecon == null)
            {
                return new Order { Coordinate = new Coordinate(), Type = OrderType.Recon };
            }

            var lastOrder = game.Orders?.LastOrDefault();

            if (lastOrder == null || lastOrder.PlayerTargeted != playerToRecon.PlayerName)
            {
                return new Order { Coordinate = playerToRecon.StartCoordinate, PlayerTargeted = playerToRecon.PlayerName, Type = OrderType.Recon };
            }

            var xStart = playerToRecon.StartCoordinate.X;
            var xLimit = playerToRecon.EndCoordinate.X;

            var yStart = playerToRecon.StartCoordinate.Y;
            var yLimit = playerToRecon.EndCoordinate.Y;

            var currentX = lastOrder.Coordinate.X + 3;
            var currentY = lastOrder.Coordinate.Y;

            if (currentX > xLimit)
            {
                currentX = xStart;
                currentY += 3;
            }

            var reconCoordinate = new Coordinate(currentX, currentY);

            return new Order { Coordinate = reconCoordinate, PlayerTargeted = playerToRecon.PlayerName, Type = OrderType.Recon };
        }
    }
}
