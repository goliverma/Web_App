using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using demo_models.Table;
using Microsoft.EntityFrameworkCore;

namespace demo_web.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext context;

        public AccountRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Account> find(string name)
        {
            return await context.Accounts.FirstOrDefaultAsync(x => x.username == name);
        }

        public async Task<bool> loginDetails(Account log)
        {
            bool istrue = false;
            if(log != null)
            {
                var result = await context.Accounts.Where(l => 
                l.username == log.username &&
                l.password == log.password).FirstOrDefaultAsync();
                if(result != null)
                {
                    istrue = true;
                }
            }
            return istrue;
        }

        public async Task<Account> register(Account user)
        {
            var result = await context.Accounts.AddAsync(user);
            await context.SaveChangesAsync();
            return result.Entity;
        }
    }
}