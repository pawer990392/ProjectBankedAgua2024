using WaterSystem.Domain.Entities;
using WaterSystem.Infrastructure.Commons.Bases.Request;
using WaterSystem.Infrastructure.Commons.Bases.Response;

namespace WaterSystem.Infrastructure.Persistences.Interfaces
{
    public interface ISettlementRepository : IGenericRepository<Settlement>
    {
        Task<BaseEntityResponse<Settlement>> ListSettlementies(BaseFiltersRequest filters);
        //Task<IEnumerable<Settlement>> ListSelectSettlement();
        //Task<Settlement> SettlementById(int settlementById);
        //Task<bool> RegisterSettlemet(Settlement entity);
        //Task<bool> UpdateSettlemet(Settlement entity);
        //Task<bool> DeleteSettlemet(int settlementById);
    }
}
