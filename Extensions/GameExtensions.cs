using BattleshipGoogleCloud.Models;
using System;
using System.Linq;

namespace BattleshipGoogleCloud.Extensions
{
    public static class GameExtensions
    {
        private static string _playerName = "Choiboi";

        private static bool checkReconCoordinates = false;

        private static int positiveReconX = 0;

        private static int positiveReconY = 0;

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

            var targetCoordinate = getReconCoordinates(playerToTarget, lastOrder);

            if (lastOrder.Result == OrderResult.ShipFound)
            {
                checkReconCoordinates = true;
                positiveReconX = lastOrder.Coordinate.X;
                positiveReconY = lastOrder.Coordinate.Y;
            }

            if (checkReconCoordinates)
            {
                targetCoordinate = getAttackCoordinates(playerToTarget, lastOrder, positiveReconX, positiveReconY);
            }


            return new Order { Coordinate = targetCoordinate, PlayerTargeted = playerToTarget.PlayerName, Type = OrderType.Attack };
        }


        public static Coordinate getAttackCoordinates(PlayerInfo playerToTarget, Order lastOrder, int startX, int startY)
        {
            var xStart = playerToTarget.StartCoordinate.X;
            var xLimit = playerToTarget.EndCoordinate.X;

            var currentX = lastOrder.Coordinate.X + 1;
            var currentY = lastOrder.Coordinate.Y;

            if (currentX > xLimit)
            {
                currentX = xStart;
                currentY += 1;
            }

            return new Coordinate(currentX, currentY);
        }

        public static Coordinate getReconCoordinates(PlayerInfo playerToTarget, Order lastOrder)
        {
            var xStart = playerToTarget.StartCoordinate.X;
            var xLimit = playerToTarget.EndCoordinate.X;
            var targetCoordinate = new Coordinate();

            if (lastOrder.Result == OrderResult.ShipFound)
            {
                  
            }

            var currentX = lastOrder.Coordinate.X + 3;
            var currentY = lastOrder.Coordinate.Y;

            if (currentX > xLimit)
            {
                currentX = xStart;
                currentY += 3;
            }


            return new Coordinate(currentX, currentY);
        }
    }
}
