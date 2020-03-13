using System.Diagnostics;
using BattleshipGoogleCloud.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipGoogleCloud.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BroadcastController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody]Message message)
        {
            Debug.WriteLine("Message type is: {0}", message.Updatetype);
            return Ok("Message received");
        }
    }
}