using DixitOnline.Business.Services.Interfaces;
using DixitOnline.DataAccess;
using DixitOnline.Models.RoomData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixitOnline.Business.Services
{
    public class RoomService : RepoScopedService<RoomModel>, IRoomService
    {
        public RoomService(IGenericRepository<RoomModel> genericRepo) : base(genericRepo) { }

        public string GenerateRoomCode()
        {
            _genericRepo.Single(x => x.)
        }
    }
}
