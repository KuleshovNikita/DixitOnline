using DixitOnline.Business.Services.Interfaces;
using DixitOnline.Models.RoomData;
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
        public async Task<GenericServiceResult<RoomModel>> RegisterNewRoom([FromBody] string roomCode)
        {
            if(string.IsNullOrEmpty(roomCode))
            {
                var res = await _roomService.GenerateRoomCode();

                if(!res.IsSuccessful)
                {
                    return new GenericServiceResult<RoomModel>();
                }

                roomCode = res.Value;
            }

            var result = new GenericServiceResult<string>()
                        .Do(() => _roomService.CreateRoom(roomCode)) as GenericServiceResult<RoomModel>;

            var room = new RoomModel
            {
                RoomCode = result.Value.RoomCode,
                RoomId = (_roomService.First(r => r.RoomCode == result.Value.RoomCode) as GenericServiceResult<RoomModel>).Value.RoomId
            };

            return result;
        }
    }
}
