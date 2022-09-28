using DixitOnline.ServiceResulting;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace DixitOnline.DataAccess
{
    public interface IGenericRepository<TEntity>
    {
        ServiceResult<Empty> Insert(TEntity model);

        Task<ServiceResult<TEntity>> First(Expression<Func<TEntity, bool>> command);

        Task<ServiceResult<TScope>> Max<TScope>(Expression<Func<TEntity, TScope>> command);
    }
}