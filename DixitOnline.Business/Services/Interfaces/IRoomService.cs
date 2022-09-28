using DixitOnline.Models.RoomData;
using DixitOnline.ServiceResulting;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DixitOnline.Business.Services.Interfaces
{
    public interface IRoomService
    {
        Task<GenericServiceResult<string>> GenerateRoomCode();

        IServiceResult CreateRoom(string roomCode);

        IServiceResult First(Expression<Func<RoomModel, bool>> command);
    }
}
