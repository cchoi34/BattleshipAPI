using System.Threading.Tasks;
using BattleshipGoogleCloud.Extensions;
using BattleshipGoogleCloud.Models;
using BattleshipGoogleCloud.Services;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipGoogleCloud.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NextOrderController : ControllerBase
    {
        private readonly IStorageService _storageService;
        public NextOrderController(IStorageService storageService)
        {
            _storageService = storageService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var game = await _storageService.GetGame("game");

            var order = game.GetNextOrder();

            game.Orders.Add(order);
            await _storageService.SaveGame(game, "game");


            return Ok(order);
            
        }
    }
}