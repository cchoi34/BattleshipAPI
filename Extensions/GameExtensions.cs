using BattleshipGoogleCloud.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BattleshipGoogleCloud.Extensions
{
    public static class GameExtensions
    {
        private static string _playerName = "Choiboi";

        private static List<Coordinate> coordinatesHit = new List<Coordinate>();

        private static bool finishOff = false;

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

            var nextOrderType = "attack";

            /*if (lastOrder.Result) 
            {
                nextOrderType = "recon";
            } 
            if (lastOrder.Result.Equals(OrderResult.ShipFound))
            {
                nextOrderType = "attack";
                if (lastOrder.Type == OrderType.Recon) {
                    //recentRecon = new Coordinate(lastOrder.Coordinate.X, lastOrder.Coordinate.Y);
                }
            } */


            var targetCoordinate = getNextCoordinates(nextOrderType, playerToTarget, lastOrder);

            /* if (nextOrderType == "recon") 
            {
                return new Order { Coordinate = targetCoordinate, PlayerTargeted = playerToTarget.PlayerName, Type = OrderType.Recon };
            } */

            if (nextOrderType == "attack") 
            {
                return new Order { Coordinate = targetCoordinate, PlayerTargeted = playerToTarget.PlayerName, Type = OrderType.Attack };
            }

            return new Order { Coordinate = targetCoordinate, PlayerTargeted = playerToTarget.PlayerName, Type = OrderType.Recon };
        }


        public static Coordinate getNextCoordinates(string type, PlayerInfo playerToTarget, Order lastOrder) {
            var xStart = playerToTarget.StartCoordinate.X;
            var xLimit = playerToTarget.EndCoordinate.X;
            var yStart = playerToTarget.StartCoordinate.Y;
            var yLimit = playerToTarget.EndCoordinate.Y;

            /*var xReconStart = recentRecon.X;
            var xReconEnd = recentRecon.X + 3;
            var yReconEnd = recentRecon.Y + 3; */

            var currentX = lastOrder.Coordinate.X;
            var currentY = lastOrder.Coordinate.Y;

           /*if (lastOrder.Result.Equals(OrderResult.ShipHit)) 
            {
                currentX -= 1;
            } */

            if (type == "attack" && !finishOff) 
            {
                currentX += 2;

                if (currentX > xLimit) 
                {
                    currentY += 1;
                    currentX = xStart + (currentY % 2);

                    if (currentY > yLimit && !playerToTarget.FleetSunk)
                    {
                        finishOff = true;
                    }
                }
                
                /* if (currentX > xReconEnd) 
                {
                    currentX = xReconStart + (currentY % 2);
                    currentY += 1;
                    if (currentY == yReconEnd) {
                        resetRecentRecon();
                    }
                } */
            }

            if (finishOff && currentY > yLimit)
            {
                currentY = yStart;
                currentX = xStart - 1; // offset attacks so they attack every grid not hit previously
            }

            if (type == "attack" && finishOff)
            {
                currentX += 2;

                if (currentX > xLimit)
                {
                    currentY += 1;
                    currentX = xStart + (1 - (currentY % 2));
                }
            }

            if (type == "recon")
            {
                currentX += 3;
                
                if (currentX > xLimit) 
                {
                    currentX = xStart;
                    currentY += 3;
                }
            }

            return new Coordinate(currentX, currentY);
        } 

        /* public static void resetRecentRecon() {
            startNewRecon = true;
            recentRecon = new Coordinate();
            nextOrderType = "recon";
        } */
    }

}
