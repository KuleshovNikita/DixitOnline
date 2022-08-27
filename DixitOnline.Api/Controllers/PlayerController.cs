using DixitOnline.Models.PlayerData;
using Microsoft.AspNetCore.Mvc;

namespace DixitOnline.Api.Controllers
{
    [Route("players")]
    public class PlayerController : Controller
    {
        [HttpGet]
        public PlayerModel GetPlayer()
        {
            return new PlayerModel
            {
                Name = "Mykyta",
                PlayerId = 1
            };
        }
    }
}
