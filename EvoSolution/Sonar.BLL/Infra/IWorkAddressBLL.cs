using Sonar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonar.BLL.Infra
{
    public interface IAddressBLL
    {
        Task AddAddress(Address workAddress);
        Task<Address> GetAddressAsync(Guid id);
    }
}
