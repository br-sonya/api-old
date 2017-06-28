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
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public AddressRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Address> GetWorkAddressAddressAsync(Guid id)
        {
            return await (from h in _dbContext.QueryAddress
                          where h.Id == id
                          select h).FirstOrDefaultAsync();
        }

        public void Add(Address address)
        {
            _dbContext.Add(address);
        }
    }
}
