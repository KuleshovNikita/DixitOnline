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

        public ServiceResult<Empty> Insert(TEntity model)
        {
            try
            {
                var a = _context.Set<TEntity>().Add(model);
                _context.SaveChanges();

                return new ServiceResult<Empty>().Success();
            } 
            catch(Exception ex)
            {
                return new ServiceResult<Empty> { Exception = ex }.Fail();
            }
        }

        public async Task<ServiceResult<TScope>> Max<TScope>(Expression<Func<TEntity, TScope>> command)
        {
            try
            {
                var dbSet = _context.Set<TEntity>();

                if(!dbSet.Any())
                {
                    return new ServiceResult<TScope>(default(TScope)).Success();
                }

                var result = await dbSet.MaxAsync(command);

                return new ServiceResult<TScope>(result).Success();
            }
            catch (Exception ex)
            {
                return new ServiceResult<TScope> { Exception = ex }.Fail();
            }
        }

        public async Task<ServiceResult<TEntity>> First(Expression<Func<TEntity, bool>> command)
        {
            try
            {
                var result = await _context.Set<TEntity>().FirstAsync(command);

                return new ServiceResult<TEntity>(result).Success();
            }
            catch (InvalidOperationException ex)
            {
                return new ServiceResult<TEntity> { Exception = ex }.Fail();
            }
            catch (Exception ex)
            {
                return new ServiceResult<TEntity> { Exception = ex }.Fail();
            }
        }
    }
}
