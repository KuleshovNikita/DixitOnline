using DixitOnline.Business.Services.Interfaces;
using DixitOnline.ServiceResulting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DixitOnline.Api.Controllers
{
    [Route("rooms")]
    public class RoomController : ResultingController
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        [Route("newRoom")]
        public async Task<GenericServiceResult<string>> RegisterNewRoom([FromBody] string roomCode)
        {
            if(string.IsNullOrEmpty(roomCode))
            {
                var res = await _roomService.GenerateRoomCode();

                if(!res.IsSuccessful)
                {
                    return res;
                }

                roomCode = res.Value;
            }

            var a = new GenericServiceResult<string>()
                        .Do(() => _roomService.CreateRoom(roomCode));

            return a;
        }
    }
}
