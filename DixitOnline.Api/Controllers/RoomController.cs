using Microsoft.AspNetCore.Mvc;

namespace DixitOnline.Api.Controllers
{
    [Route("rooms")]
    public class RoomController : Controller
    {
        [HttpPost]
        [Route("newRoom")]
        public string RegisterNewRoom([FromBody] string roomCode)
        {
            return null;
        }
    }
}
