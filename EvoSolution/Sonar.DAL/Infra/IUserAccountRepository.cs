﻿using Sonar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonar.DAL.Infra
{
    public interface IUserAccountRepository
    {
        void AddAccount(UserAccount account);
        Task<UserAccount> GetUserInfoAsync(Guid id);
        void EditUserAccountInfo(UserAccount user);
        Task<UserAccount> Login(string email, string password);
        Task<UserAccount> GetUserByEmail(string email);
    }
}
