using Sonar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonar.DAL.Infra
{
    public interface IAddressRepository
    {
        void Add(Address workAddress);
        Task<Address> GetWorkAddressAddressAsync(Guid id);

    }
}
