using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<int> SaveAdminData(AccountModel _accountModel);
    }
}
