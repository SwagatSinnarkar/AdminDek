using Domain.Models;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAccount
    {
        Task<int> SaveAdminData(AccountModel _accountModel);
    }
}
