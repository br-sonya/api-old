using Sonar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonar.DAL.Infra
{
    public interface IStateRepository
    {
        void Add(State state);
        Task<List<State>> GetStatesAsync();
    }
}
