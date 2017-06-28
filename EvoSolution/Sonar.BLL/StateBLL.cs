using Sonar.BLL.Infra;
using Sonar.DAL;
using Sonar.DAL.Infra;
using Sonar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonar.BLL
{
    public class StateBLL : IStateBLL
    {
        private IStateRepository _stateRepository;
        private IDbContext _dbContext;

        public StateBLL(IStateRepository stateRepository, IDbContext dbContext)
        {
            _stateRepository = stateRepository;
            _dbContext = dbContext;
        }

        public async Task AddState(State state)
        {
            _stateRepository.Add(state);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<State>> GetStatesAsync()
        {
            return _stateRepository.GetStatesAsync();
        }

    }
}
