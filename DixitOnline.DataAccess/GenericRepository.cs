using DixitOnline.DataAccess.Context;
using DixitOnline.ServiceResulting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DixitOnline.DataAccess
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;

        public GenericRepository(DixitOnlineDbContext context)
        {
            _context = context;
        }

        public ServiceResult Insert(TEntity model)
        {
            try
            {
                _context.Set<TEntity>().Add(model);
                _context.SaveChanges();

                return new ServiceResult().Success();
            } 
            catch(Exception ex)
            {
                return new ServiceResult { Exception = ex }.Fail();
            }
        }

        public async Task<ServiceResult> Max(Expression<Func<TEntity, int>> command)
        {
            try
            {
                var dbSet = _context.Set<TEntity>();

                if(!dbSet.Any())
                {
                    return new GenericServiceResult<int>(-1).Success();
                }

                var result = await dbSet.MaxAsync(command);

                return new GenericServiceResult<int>(result).Success();
            }
            catch (Exception ex)
            {
                return new GenericServiceResult<int> { Exception = ex }.Fail();
            }
        }
    }
}
