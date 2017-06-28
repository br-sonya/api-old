using Sonar.DAL.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sonar.Entities;
using System.Data.Entity;

namespace Sonar.DAL
{
    public class StateRepository : RepositoryBase, IStateRepository
    {
        
        public StateRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public void Add(State state)
        {
            _dbContext.Add(state);
        }

        public Task<List<State>> GetStatesAsync()
        {
            return _dbContext.QueryState.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
