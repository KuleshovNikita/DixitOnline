using DixitOnline.Models.PlayerData;
namespace DixitOnline.Business.Services.Interfaces
{
    public interface IPlayerService
    {
        void RegisterPlayer(PlayerModel playerModel);
    }
}
