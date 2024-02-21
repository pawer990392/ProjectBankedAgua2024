using Microsoft.EntityFrameworkCore;
using WaterSystem.Domain.Entities;
using WaterSystem.Infrastructure.Persistences.Contexts;
using WaterSystem.Infrastructure.Persistences.Interfaces;

namespace WaterSystem.Infrastructure.Persistences.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly SistemasCobroAgua2024Context _context;
        public UserRepository(SistemasCobroAgua2024Context Context):base(Context)
        {
            this._context = Context;
        }

        public async Task<User> AccountByUserName(string userName)
        {
            var account = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName!.Equals(userName));

            return account!;


        }

    }
}
