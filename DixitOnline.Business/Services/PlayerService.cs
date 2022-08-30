using DixitOnline.Business.Services.Interfaces;
using DixitOnline.DataAccess;
using DixitOnline.Models.PlayerData;
using System;

namespace DixitOnline.Business.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IGenericRepository<PlayerModel> _genericRepo;

        public PlayerService(IGenericRepository<PlayerModel> genericRepo)
        {
            _genericRepo = genericRepo;
        }

        public void RegisterPlayer(PlayerModel playerModel)
        {
            if(playerModel == null)
            {
                throw new ArgumentNullException(nameof(playerModel), $"argument {nameof(playerModel)} was null");
            }

            _genericRepo.Insert(playerModel);
        }
    }
}
