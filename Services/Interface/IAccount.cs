using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAccount
    {
        Task<int> SaveAdminData(AccountModel _accountModel);
        Task<int> UpdateAdminData(AccountModel _accountModel);
        Task<IEnumerable<AccountModel>> GetAdminUserData(string tableName, string Id);
    }
}
