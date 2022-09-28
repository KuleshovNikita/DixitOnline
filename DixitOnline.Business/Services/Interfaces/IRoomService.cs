using DixitOnline.Models.RoomData;
using DixitOnline.ServiceResulting;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DixitOnline.Business.Services.Interfaces
{
    public interface IRoomService
    {
        ServiceResult<string> GenerateRoomCode();

        AbstractServiceResult CreateRoom(string roomCode);

        AbstractServiceResult First(Expression<Func<RoomModel, bool>> command);
    }
}
