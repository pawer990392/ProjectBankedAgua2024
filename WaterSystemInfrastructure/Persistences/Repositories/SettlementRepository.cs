using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WaterSystem.Domain.Entities;
using WaterSystem.Infrastructure.Commons.Bases.Request;
using WaterSystem.Infrastructure.Commons.Bases.Response;
using WaterSystem.Infrastructure.Persistences.Contexts;
using WaterSystem.Infrastructure.Persistences.Interfaces;

namespace WaterSystem.Infrastructure.Persistences.Repositories
{
    public class SettlementRepository : GenericRepository<Settlement>,ISettlementRepository
    {
        //private readonly SistemasCobroAgua2024Context _context;

        public SettlementRepository(SistemasCobroAgua2024Context Context):base(Context)
        {
            
        }

        //public async Task<bool> DeleteSettlemet(int settlementById)
        //{
        //    var settlementRegister = await _context.Settlements!.AsNoTracking().FirstOrDefaultAsync(x => x.IdSettlement == settlementById);

        //    if (settlementRegister != null)
        //    {
        //        _context.Settlements.Remove(settlementRegister);
        //        var recordsAffect = await _context.SaveChangesAsync();
        //        return recordsAffect > 0;
        //    }
        //    else {
        //        return false;
        //    }
        //}

        //public async Task<IEnumerable<Settlement>> ListSelectSettlement()
        //{
        //    var settlement = await _context.Settlements.AsNoTracking().ToListAsync();
        //    return settlement;
        //}

        public async Task<BaseEntityResponse<Settlement>> ListSettlementies(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Settlement>();

            //var settlement = (from s in _context.Settlements
            //                  select s).AsNoTracking().AsQueryable();

            var settlement = GetEntityQuery();

            //condicion de los filtors
            //filtra con datos correspodiente en texto
            if (filters.NumFilter!=null && !string.IsNullOrEmpty(filters.TextFilter))
            {
            
                switch(filters.NumFilter)
                {
                    case 1:
                        settlement = settlement.Where(x => x.Name!.Contains(filters.TextFilter));
                        break;          
                }
            }
            //filtro de estados igual se puede pero no lo necesutaos sera en otro momento

            //filtrar por rango de fecha
            if(!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                settlement = settlement.Where(x => x.CreateDate >= Convert.ToDateTime(filters.StartDate) && x.EditDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));

            }
            //orrdenado por un campo por defecto
            if(filters.Sort is null)
            {
                filters.Sort = "Id";
            }
            //regresmos total de regisatro y items
            response.TotalRecords= await settlement.CountAsync();
            response.Items = await Ordering(filters, settlement,!(bool)filters.Download!).ToListAsync();
            return response;
        }

        //public async Task<bool> RegisterSettlemet(Settlement entity)
        //{
        //    entity.CreateUser = 1;
        //    entity.CreateDate = DateTime.Now;
        //    entity.EditUser = 1;
        //    entity.EditDate= DateTime.Now;

        //    await _context.AddAsync(entity);
        //    var recordsAffect = await _context.SaveChangesAsync();
        //    return recordsAffect > 0;

        //}

        //public async Task<Settlement> SettlementById(int settlementById)
        //{
        //    var settlementRegister = await _context.Settlements!.AsNoTracking().FirstOrDefaultAsync(x =>x.IdSettlement==settlementById);
        //    return settlementRegister!;
        //}

        //public async Task<bool> UpdateSettlemet(Settlement entity)
        //{
        //    entity.EditUser = 1;
        //    entity.EditDate = DateTime.Now;

        //    _context.Update(entity);
        //    _context.Entry(entity).Property(x => x.CreateUser).IsModified = false;
        //    _context.Entry(entity).Property(x => x.CreateDate).IsModified = false;
        //    var recordsAffect = await _context.SaveChangesAsync();
        //    return recordsAffect > 0;
        //}
    }
}
