using DixitOnline.DataAccess;

namespace DixitOnline.Business.Services
{
    public abstract class RepoScopedService<TRepoModel>
    {
        protected readonly IGenericRepository<TRepoModel> _genericRepo;

        public RepoScopedService(IGenericRepository<TRepoModel> genericRepo)
        {
            _genericRepo = genericRepo;
        }
    }
}
