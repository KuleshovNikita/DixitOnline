using Microsoft.AspNetCore.Mvc;

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
        public string RegisterNewRoom([FromBody] string roomCode)
        {
            if(string.IsNullOrEmpty(roomCode))
            {

            }
        }
    }
}
