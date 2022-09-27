using DixitOnline.Business.Crypto;
using DixitOnline.Business.Services.Interfaces;
using DixitOnline.DataAccess;
using DixitOnline.Models.RoomData;
using DixitOnline.ServiceResulting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DixitOnline.Business.Services
{
    public class RoomService : RepoScopedService<RoomModel>, IRoomService
    {
        private readonly int _roomCodeLength;

        public RoomService(IGenericRepository<RoomModel> genericRepo, IConfiguration configuration) : base(genericRepo) 
        {
            _roomCodeLength = int.Parse(configuration.GetSection("EnvironmentConstants:RoomCodeLength").Value);
        }

        public async Task<GenericServiceResult<string>> GenerateRoomCode()
        {
            var repoResult =
                new GenericServiceResult<int>()
                    .Do(() => _genericRepo.Max(x => x.RoomId).Result);

            if(!repoResult.IsSuccessful)
            {
                return new GenericServiceResult<string>
                {
                    Exception = repoResult.Exception
                }
                .Fail();
            }

            var maxRoomId = repoResult.Value == -1 
                                ? new Random().Next(0, 100)
                                : repoResult.Value;

            var currentTime = DateTime.Now;
            var longKey = Math.Abs(currentTime.Millisecond * currentTime.Ticks * maxRoomId);

            var normalisedKey = string.Join(string.Empty, 
                                            longKey.ToString()
                                                   .Replace(" ", string.Empty)
                                                   .Take(_roomCodeLength));

            var roomCode = CaesarEncryption.Encrypt(normalisedKey);

            return new GenericServiceResult<string>(roomCode).Success();
        }

        public GenericServiceResult<string> CreateRoom(string roomCode)
            => new GenericServiceResult<string>()
                .Do(() => _genericRepo.Insert(new RoomModel { RoomCode = roomCode } ))
                .Catch<DbUpdateException>("Server error, the room was not created")
                .Catch<DbUpdateConcurrencyException>("Server error, the room was not created");
    }
}
