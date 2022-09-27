using DixitOnline.ServiceResulting;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace DixitOnline.DataAccess
{
    public interface IGenericRepository<TEntity>
    {
        ServiceResult Insert(TEntity model);

        Task<GenericServiceResult<int>> Max(Expression<Func<TEntity, int>> command);
    }
}