using Sonar.DAL.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sonar.Entities;
using System.Data.Entity;
using Sonar.Framework.Helpers;

namespace Sonar.DAL
{
    public class UserAccountRepository : RepositoryBase, IUserAccountRepository
    {
        public UserAccountRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void AddAccount(UserAccount user)
        {
            _dbContext.Add(user);
        }

        public void EditUserAccountInfo(UserAccount user)
        {
            _dbContext.Edit(user);
        }

        public async Task<UserAccount> GetUserInfoAsync(Guid id)
        {
            return await(from h in _dbContext.QueryUserAccount
                         where h.Id == id
                         select h).FirstOrDefaultAsync();
        }

        public async Task<UserAccount> GetUserByEmail(string email)
        {
            return await (from h in _dbContext.QueryUserAccount
                          where h.Email == email
                          select h).FirstOrDefaultAsync();
        }

        public async Task<UserAccount> Login(string email, string password)
        {
            return await (from u in _dbContext.QueryUserAccount
                          where (u.Email == email && u.Password == password)
                          select u).FirstOrDefaultAsync();
        }
    }
}
