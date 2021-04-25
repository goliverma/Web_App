using System.Threading.Tasks;
using demo_models.Table;

namespace demo_web.Data.Repository
{
    public interface IAccountRepository
    {
        Task<bool> loginDetails(Account use);
        Task<Account> register(Account user);
        Task<Account> find(string name);
    }
}