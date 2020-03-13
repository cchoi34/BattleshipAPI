using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleshipGoogleCloud.Helpers;
using BattleshipGoogleCloud.Models;
using BattleshipGoogleCloud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipGoogleCloud.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameUpdatesController : ControllerBase
    {
        private readonly IStorageService _storageService;
        public GameUpdatesController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            if (order.Result == OrderResult.ShipSunk)
            {
                var game = await _storageService.GetGame("game");
                GameUpdatesHelper updatesHelper = new GameUpdatesHelper(order);
                game.GameInfo.Players = updatesHelper.UpdatePlayerInfo(game.GameInfo.Players);

                await _storageService.SaveGame(game, "game");
            }

            return Ok();
        }
    }
}