using DixitOnline.DataAccess.Context;
using DixitOnline.Models.RoomData;
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

        public IServiceResult Insert(TEntity model)
        {
            try
            {
                var a = _context.Set<TEntity>().Add(model);
                _context.SaveChanges();

                return new ServiceResult().Success();
            } 
            catch(Exception ex)
            {
                return new ServiceResult { Exception = ex }.Fail();
            }
        }

        public IServiceResult InsertAndReturn(TEntity model)
        {
            try
            {
                _context.Set<TEntity>().Add(model);
                _context.SaveChanges();

                return new GenericServiceResult<TEntity>(model).Success();
            }
            catch (Exception ex)
            {
                return new GenericServiceResult<TEntity> { Exception = ex }.Fail();
            }
        }

        public async Task<IServiceResult> Max(Expression<Func<TEntity, int>> command)
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

        public async Task<IServiceResult> First(Expression<Func<TEntity, bool>> command)
        {
            try
            {
                var result = await _context.Set<TEntity>().FirstAsync(command);

                return new GenericServiceResult<TEntity>(result).Success();
            }
            catch (InvalidOperationException ex)
            {
                return new GenericServiceResult<TEntity> { Exception = ex }.Fail();
            }
            catch (Exception ex)
            {
                return new GenericServiceResult<TEntity> { Exception = ex }.Fail();
            }
        }
    }
}
