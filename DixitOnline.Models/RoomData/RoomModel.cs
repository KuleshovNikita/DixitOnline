using DixitOnline.Models.PlayerData;
using System.Collections.Generic;

namespace DixitOnline.Models.RoomData
{
    public class RoomModel
    {
        public int RoomId { get; set; }

        public string RoomCode { get; set; }

        public IEnumerable<PlayerModel> Players { get; set; }
    }
}
