using Sonar.BLL.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sonar.Entities;
using Sonar.DAL.Infra;
using Sonar.DAL;
using Sonar.BLL.Exceptions;

namespace Sonar.BLL
{
    public class AddressBLL : IAddressBLL
    {
        private IAddressRepository _workAddressRepository;
        private IDbContext _dbContext;

        public AddressBLL(IAddressRepository workAddressRepository, IDbContext dbContext)
        {
            _workAddressRepository = workAddressRepository;
            _dbContext = dbContext;
        }

        public async Task AddAddress(Address workAddress)
        {
            try
            {
                var result = await _workAddressRepository.GetWorkAddressAddressAsync(workAddress.UserAccountId);
                if (result != null)
                {
                    result.Location = workAddress.Location;
                    result.Neighborhood = workAddress.Neighborhood;
                    result.Number = workAddress.Number;
                    result.StateId = workAddress.StateId;
                    result.Cep = workAddress.Cep;
                    result.City = workAddress.City;
                    _dbContext.Edit(result);
                }
                else
                {
                    _workAddressRepository.Add(workAddress);

                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BusinessException("Houve um erro ao fazer alteração de endereço.");
            }

        }

        public async Task<Address> GetAddressAsync(Guid id)
        {
            try
            {
                return await _workAddressRepository.GetWorkAddressAddressAsync(id);

            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }
    }
}
