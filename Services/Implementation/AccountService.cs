using Domain.Models;
using Domain.Repositories;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Services.Implementation
{
    public class AccountService : IAccount
    {
        private AccountRepository _accountRepository;

        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public Task<int> SaveAdminData(AccountModel _accountModel)
        {
            return Task.Factory.StartNew(() =>
            {
                return _accountRepository.SaveAdminData(_accountModel);
            });
        }

        public Task<int> UpdateAdminData(AccountModel _accountModel)
        {
            return Task.Factory.StartNew(() =>
            {
                return _accountRepository.UpdateAdminData(_accountModel);
            });
        }

        public Task<IEnumerable<AccountModel>> GetAdminUserData(string tableName, string Id)
        {
            return Task.Factory.StartNew(() =>
            {
                return _accountRepository.GetAdminUserData(tableName, Id);
            });
        }
    }
}