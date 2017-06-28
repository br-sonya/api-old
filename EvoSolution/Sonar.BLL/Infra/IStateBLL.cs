using Sonar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonar.BLL.Infra
{
    public interface IStateBLL
    {
        Task AddState(State state);
        Task<List<State>> GetStatesAsync();
    }
}
