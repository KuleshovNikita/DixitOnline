using DixitOnline.Models.RoomData;
using DixitOnline.ServiceResulting;
using System;
using System.Linq.Expressions;

namespace DixitOnline.Business.Services.Interfaces
{
    public interface IRoomService
    {
        ServiceResult<string> GenerateRoomCode();

        ServiceResult<Empty> CreateRoom(string roomCode);

        ServiceResult<RoomModel> First(Expression<Func<RoomModel, bool>> command);
    }
}
