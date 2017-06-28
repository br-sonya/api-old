using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonar.BLL.Infra;
using Sonar.DAL;

namespace Sonar.Web.UoW
{
    public class StateUoW : UoWBase
    {
        public IStateBLL StateBLL { get; private set; }
        public StateUoW(IStateBLL stateBLL, IDbContext dbContext) : base(dbContext)
        {
            StateBLL = stateBLL;
        }
    }
}