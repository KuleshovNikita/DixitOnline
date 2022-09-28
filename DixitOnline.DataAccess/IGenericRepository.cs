using DixitOnline.ServiceResulting;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using DixitOnline.Models.RoomData;

namespace DixitOnline.DataAccess
{
    public interface IGenericRepository<TEntity>
    {
        AbstractServiceResult Insert(TEntity model);

        AbstractServiceResult InsertAndReturn(TEntity model);

        Task<AbstractServiceResult> First(Expression<Func<TEntity, bool>> command);

        Task<AbstractServiceResult> Max(Expression<Func<TEntity, int>> command);
    }
}