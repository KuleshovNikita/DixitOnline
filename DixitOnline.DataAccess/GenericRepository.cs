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

        public async Task<ServiceResult<TFindBy>> Max<TFindBy>(Expression<Func<TEntity, TFindBy>> command)
        {
            try
            {
                var dbSet = _context.Set<TEntity>();

                if(!dbSet.Any())
                {
                    return new ServiceResult<TFindBy>(default(TFindBy)).Success();
                }

                var result = await dbSet.MaxAsync(command);

                return new ServiceResult<TFindBy>(result).Success();
            }
            catch (Exception ex)
            {
                return new ServiceResult<TFindBy> { Exception = ex }.Fail();
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
