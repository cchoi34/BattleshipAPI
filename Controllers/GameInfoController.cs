using System.Threading.Tasks;
using BattleshipGoogleCloud.Models;
using BattleshipGoogleCloud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloBattleshipGoogleCloudWorld.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameInfoController : ControllerBase
    {
        private readonly IStorageService _storageService;
        public GameInfoController(IStorageService storageService)
        {
            _storageService = storageService;   
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GameInfo gameInfo)
        {
            var game = new Game();
            game.GameInfo = gameInfo;

            var success = await _storageService.SaveGame(game, "game");

            if (success)
            {
                return Ok();
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}