using WaterSystem.Domain.Entities;

namespace WaterSystem.Infrastructure.Persistences.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        
        Task<User> AccountByUserName(string userName);

    }
}
