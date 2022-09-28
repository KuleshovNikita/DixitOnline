using DixitOnline.Models.PlayerData;
using DixitOnline.ServiceResulting;

namespace DixitOnline.Business.Services.Interfaces
{
    public interface IPlayerService
    {
        ServiceResult RegisterPlayer(PlayerModel playerModel);
    }
}
