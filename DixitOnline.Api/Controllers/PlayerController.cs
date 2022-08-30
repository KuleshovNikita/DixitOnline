using DixitOnline.Business.Services.Interfaces;
using DixitOnline.Models.PlayerData;
using Func;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DixitOnline.Api.Controllers
{
    [Route("players")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public PlayerModel GetPlayer()
        {
            return new PlayerModel
            {
                Name = "Mykyta",
                PlayerId = 1
            };
        }

        [HttpPost]
        [Route("newPlayer")]
        public void RegisterNewPlayer([FromBody] PlayerModel player)
        {
            _playerService.RegisterPlayer(player);
        }   
    }
}
