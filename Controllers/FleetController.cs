using BattleshipGoogleCloud.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipGoogleCloud.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FleetController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Fleet fleet = new Fleet("Choiboi");

            fleet.AircraftCarrier.PositionRelative = new Coordinate(13, 18);
            fleet.AircraftCarrier.Orientation = ShipOrientation.Horizontal;

            fleet.Battleship.PositionRelative = new Coordinate(9, 12);
            fleet.Battleship.Orientation = ShipOrientation.Horizontal;

            fleet.Destroyer.PositionRelative = new Coordinate(7, 8);
            fleet.Destroyer.Orientation = ShipOrientation.Vertical;

            fleet.PTBoat.PositionRelative = new Coordinate(15, 8);
            fleet.PTBoat.Orientation = ShipOrientation.Vertical;

            fleet.Submarine.PositionRelative = new Coordinate(4, 16);
            fleet.Submarine.Orientation = ShipOrientation.Vertical;

            return Ok(fleet);
        }
    }
}