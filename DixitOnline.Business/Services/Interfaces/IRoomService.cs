using DixitOnline.ServiceResulting;
using System.Threading.Tasks;

namespace DixitOnline.Business.Services.Interfaces
{
    public interface IRoomService
    {
        Task<GenericServiceResult<string>> GenerateRoomCode();

        GenericServiceResult<string> CreateRoom(string roomCode);
    }
}
