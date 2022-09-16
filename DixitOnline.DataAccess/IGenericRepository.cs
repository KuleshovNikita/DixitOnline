using DixitOnline.ServiceResulting;

namespace DixitOnline.DataAccess
{
    public interface IGenericRepository<TEntity>
    {
        ServiceResult Insert(TEntity model);
    }
}