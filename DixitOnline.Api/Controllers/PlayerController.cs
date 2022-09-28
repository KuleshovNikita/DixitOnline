using DixitOnline.Business.Services.Interfaces;
using DixitOnline.Models.PlayerData;
using DixitOnline.ServiceResulting;
using Microsoft.AspNetCore.Mvc;

namespace DixitOnline.Api.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayerController : ResultingController
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
                Name = string.Empty
            };
        }

        [HttpGet]
        [Route("getError")]
        public IActionResult GetPlayerError()
        {
            var pl = new PlayerModel { Name = "name" };
            return Unauthorized(pl);
        }

        [HttpPost]
        [Route("newPlayer")]
        public ServiceResult<Empty> RegisterNewPlayer([FromBody] PlayerModel player)
            => ValidateModel()
                .Do(() => _playerService.RegisterPlayer(player));
    }
}
