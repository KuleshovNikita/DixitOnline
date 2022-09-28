using DixitOnline.Business.Crypto;
using DixitOnline.Business.Services.Interfaces;
using DixitOnline.DataAccess;
using DixitOnline.Models.RoomData;
using DixitOnline.ServiceResulting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DixitOnline.Business.Services
{
    public class RoomService : RepoScopedService<RoomModel>, IRoomService
    {
        private readonly int _roomCodeLength;

        public RoomService(IGenericRepository<RoomModel> genericRepo, IConfiguration configuration) : base(genericRepo) 
        {
            _roomCodeLength = int.Parse(configuration.GetSection("EnvironmentConstants:RoomCodeLength").Value);
        }

        public ServiceResult<string> GenerateRoomCode()
        {
            var repoResult =
                new GenericServiceResult<int>()
                    .Do(() => _genericRepo.Max(x => x.RoomId).Result) as ServiceResult<int?>;

            if(!repoResult.IsSuccessful)
            {
                return (ServiceResult<string>) new GenericServiceResult<string>
                {
                    Exception = repoResult.Exception
                }
                .Fail();
            }

            var key = GenerateUniqueKey(repoResult.Value);

            var roomCode = new CaesarEncryption().Encrypt(key);

            return new GenericServiceResult<string>(roomCode).Success() as ServiceResult<string>;
        }

        private string GenerateUniqueKey(int? value)
        {
            var maxRoomId = value ?? new Random().Next(0, 100);
            var currentTime = DateTime.Now;
            var key = Math.Abs(currentTime.Millisecond * currentTime.Ticks * maxRoomId);

            var normalisedKey = string.Join(string.Empty, key.ToString()
                                                             .Replace(" ", string.Empty)
                                                             .Take(_roomCodeLength));

            return normalisedKey;
        }

        public AbstractServiceResult CreateRoom(string roomCode)
            => new GenericServiceResult<string>(roomCode)
                .Do(() => _genericRepo.InsertAndReturn(new RoomModel { RoomCode = roomCode } ))
                .Catch<DbUpdateException>("Server error, the room was not created")
                .Catch<DbUpdateConcurrencyException>("Server error, the room was not created")
                .Catch<Exception>("Unknown error, can't create a room");

        public AbstractServiceResult First(Expression<Func<RoomModel, bool>> command)
            => new GenericServiceResult<RoomModel>()
                .Do(() => _genericRepo.First(command).Result)
                .Catch<InvalidOperationException>("No room with specified code was found");
    }
}
