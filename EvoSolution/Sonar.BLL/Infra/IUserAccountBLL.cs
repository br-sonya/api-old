using Sonar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonar.BLL.Infra
{
    public interface IUserAccountBLL
    {
        Task AddAccount(UserAccount account);
        Task<UserAccount> GetUserInfoAsync(Guid id);
        Task EditUserAccountInfo(UserAccount user);
        Task<UserAccount> Login(string email, string password);
    }
}
