using DixitOnline.ServiceResulting;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using DixitOnline.Models.RoomData;

namespace DixitOnline.DataAccess
{
    public interface IGenericRepository<TEntity>
    {
        IServiceResult Insert(TEntity model);

        IServiceResult InsertAndReturn(TEntity model);

        Task<IServiceResult> First(Expression<Func<TEntity, bool>> command);

        Task<IServiceResult> Max(Expression<Func<TEntity, int>> command);
    }
}