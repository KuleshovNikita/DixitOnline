namespace DixitOnline.DataAccess
{
    public interface IGenericRepository<TEntity>
    {
        void Insert(TEntity model);
    }
}