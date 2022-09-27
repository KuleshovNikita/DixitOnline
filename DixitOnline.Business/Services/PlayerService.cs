using DixitOnline.Business.Services.Interfaces;
using DixitOnline.DataAccess;
using DixitOnline.Models.PlayerData;
using DixitOnline.ServiceResulting;
using Microsoft.EntityFrameworkCore;
using System;

namespace DixitOnline.Business.Services
{
    public class PlayerService : RepoScopedService<PlayerModel>, IPlayerService
    {
        public PlayerService(IGenericRepository<PlayerModel> genericRepo) : base(genericRepo) { }

        public ServiceResult RegisterPlayer(PlayerModel playerModel)
        {
            if(playerModel == null)
            {
                throw new ArgumentNullException(nameof(playerModel), $"argument {nameof(playerModel)} was null");
            }

            return new ServiceResult()
                    .Do(() => _genericRepo.Insert(playerModel))
                    .Catch<DbUpdateException>("Server error, the player was not registered")
                    .Catch<DbUpdateConcurrencyException>("Server error, the player was not registered");
        }
    }
}
