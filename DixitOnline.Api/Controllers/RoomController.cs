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
        public ServiceResult<RoomModel> RegisterNewRoom([FromBody] string roomCode)
        {
            if(string.IsNullOrEmpty(roomCode))
            {
                var res = _roomService.GenerateRoomCode();

                if(!res.IsSuccessful)
                {
                    return new ServiceResult<RoomModel>();
                }

                roomCode = res.Value;
            }

            var room = new ServiceResult<RoomModel>()
                                .Do(() => _roomService.CreateRoom(roomCode));

            room.Value.RoomId = _roomService.First(r => r.RoomCode == roomCode).Value.RoomId;

            return room;
        }
    }
}
