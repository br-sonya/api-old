using Sonar.BLL.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sonar.Entities;
using Sonar.DAL;
using Sonar.DAL.Infra;
using Sonar.Framework.Helpers;
using Sonar.BLL.Exceptions;

namespace Sonar.BLL
{
    public class UserAccountBLL : IUserAccountBLL
    {
        private IUserAccountRepository _userAccountRepository;
        private IDbContext _dbContext;

        public UserAccountBLL(IUserAccountRepository userAccountRepository, IDbContext dbContext)
        {
            _userAccountRepository = userAccountRepository;
            _dbContext = dbContext;
        }

        public async Task AddAccount(UserAccount account)
        {
            try
            {
                var verify = await _userAccountRepository.GetUserByEmail(account.Email);
                if (verify != null)
                {
                    throw new BusinessException("Já existe um usuário com este e-mail cadastrado.");
                }
                account.Password = Sha256Helper.Encode(account.Password);
                _userAccountRepository.AddAccount(account);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

        public Task EditUserAccountInfo(UserAccount user)
        {
            throw new NotImplementedException();
        }

        public Task<UserAccount> GetUserInfoAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAccount> Login(string email, string password)
        {
            var pass = Sha256Helper.Encode(password);
            var user = await _userAccountRepository.Login(email, pass);
            if (user == null)
                throw new BusinessException("Usuário não encontrado. Verifique seu e-mail e senha.");
            return user;
        }
    }
}
