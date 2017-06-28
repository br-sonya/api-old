using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonar.DAL;
using Sonar.BLL.Infra;

namespace Sonar.Web.UoW
{
    public class UserAccountUoW : UoWBase
    {
        public IUserAccountBLL UserAccountBLL { get; private set; }
        public UserAccountUoW(IUserAccountBLL userAccountBLL, IDbContext dbContext) : base(dbContext)
        {
            UserAccountBLL = userAccountBLL;
        }
    }
}