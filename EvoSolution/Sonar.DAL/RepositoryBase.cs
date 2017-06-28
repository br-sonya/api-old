
namespace Sonar.DAL
{
    public abstract class RepositoryBase
    {
        protected IDbContext _dbContext;

        public RepositoryBase(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }


}
