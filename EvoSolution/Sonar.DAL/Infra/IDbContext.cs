using Sonar.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sonar.DAL
{
    public interface IDbContext : IDisposable
    {
        #region Methods
        Task<int> SaveChangesAsync();
        void Add(object entity);
        void Edit(object entity);
        void Delete(object entity);
        #endregion

        #region Mapping
        IQueryable<State> QueryState { get; }
        IQueryable<Address> QueryAddress { get; }
        IQueryable<UserAccount> QueryUserAccount { get; }

        #endregion
    }
}
