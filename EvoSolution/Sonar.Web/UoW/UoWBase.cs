using Sonar.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonar.Web.UoW
{
    public abstract class UoWBase
    {
        private IDbContext _dbContext;

        public UoWBase(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }

}
