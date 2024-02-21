using System.Linq.Expressions;
using WaterSystem.Domain.Entities;
using WaterSystem.Infrastructure.Commons.Bases.Request;

namespace WaterSystem.Infrastructure.Persistences.Interfaces
{
    //CRUD DE TIPO GENERICOS ES DECIR PODEMOS HACERLO DESDE CUALUIER ENTIDAD X
    public interface IGenericRepository<T> where T : BaseEntity
    {
        //AQUI OPERACIONES CRUD para los que son genericos 
        //mwotdos genericos de un CRUD
        Task<IEnumerable<T>> GetAlltAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> RegisterEntityAsync(T entity);
        Task<bool> UpdateEntityAsync(T entity);
        Task<bool> DeleteEntityAsync(int id);
        IQueryable<T> GetEntityQuery(Expression<Func<T,bool>>? filter=null);
        IQueryable<TDto> Ordering<TDto>(BasePaginationRequest request, IQueryable<TDto> queryable, bool pagination = false) where TDto : class;
        Task<IEnumerable<T>> GetAync(Expression<Func<T,bool>>? whereCondicion = null,
                                     Func<IQueryable<T>,IOrderedQueryable<T>>? ordeBy = null,
                                     string includeProperties = "");
       


    }
}
