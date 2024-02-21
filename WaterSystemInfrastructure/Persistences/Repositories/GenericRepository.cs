using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;//saber utilizar esta libreria a gutruo para proceso de paginacion y ordenacion 
using System.Linq.Expressions;
using WaterSystem.Domain.Entities;
using WaterSystem.Infrastructure.Commons.Bases;
using WaterSystem.Infrastructure.Commons.Bases.Request;
using WaterSystem.Infrastructure.Helpers;
using WaterSystem.Infrastructure.Persistences.Contexts;
using WaterSystem.Infrastructure.Persistences.Interfaces;


namespace WaterSystem.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SistemasCobroAgua2024Context _context;
        private readonly DbSet<T> _entity;
        public GenericRepository(SistemasCobroAgua2024Context context)
        {
            _context = context;
            _entity=_context.Set<T>();

        }

        public async Task<bool> DeleteEntityAsync(int id)
        {
            T entityX = await GetByIdAsync(id);//recibimos una entidad generica

            if (entityX != null)
            {
                _entity.Remove(entityX);
                var recordAffect = await _context.SaveChangesAsync();
                return recordAffect > 0;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAlltAsync()
        {
            var getAll = await _entity.AsNoTracking().ToListAsync();
            return getAll;
        }

        

        public async Task<T> GetByIdAsync(int id)
        {
           var getById = await _entity!.AsNoTracking().FirstOrDefaultAsync(x=> x.Id.Equals(id));
            return getById!;
             
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
           IQueryable<T> query = _entity;

            if(filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }

        public async Task<bool> RegisterEntityAsync(T entity)
        {
            try
            {
                entity.CreateUser = 1;
                entity.CreateDate = DateTime.Now;
                entity.EditUser = 1;
                entity.EditDate = DateTime.Now;

                await _context.AddAsync(entity);
                var recordsAffect = await _context.SaveChangesAsync();
                return recordsAffect > 0;
            }
            catch(Exception ex)
            {
                throw new Exception("Se ha Producido un error "+ex.Message);

            }
        }

        public async Task<bool> UpdateEntityAsync(T entity)
        {
            entity.EditUser = 1;
            entity.EditDate = DateTime.Now;

            _context.Update(entity);
            _context.Entry(entity).Property(x => x.CreateUser).IsModified = false;
            _context.Entry(entity).Property(x => x.CreateDate).IsModified = false;
            var recordsAffect = await _context.SaveChangesAsync();
            return recordsAffect > 0;
        }

        //operaciones de ordenamiento
        public IQueryable<TDto> Ordering<TDto>(BasePaginationRequest request,IQueryable<TDto> queryable,bool pagination=false) where TDto : class
        {

            string sortExpression = request.Order == "desc" ? $"{request.Sort} descending" : $"{request.Sort} ascending";

            IQueryable<TDto> queryDto = queryable.OrderBy(sortExpression);

            //IQueryable<TDto> queryDto = request.Sort == "desc" ?
            //    queryable.OrderByDescending(x => EF.Property<object>(x, request.Sort)) :
            //    queryable.OrderBy(x => EF.Property<object>(x, request.Sort));


            //vale cheetos no me srive compa 
            //IQueryable<TDto> queryDto = request.Order == "desc" ?
            //                                            queryable.OrderBy($"{request.Sort} descendig") 
            //                                           : queryable.OrderBy($"{request.Sort} ascending");

            if (pagination)
            {
                queryDto = queryDto.Paginate(request);
            }
            return queryDto;
        }

        public async Task<IEnumerable<T>> GetAync(Expression<Func<T,bool>>? whereCondicion = null,
            Func<IQueryable<T>, 
            IOrderedQueryable<T>>? ordeBy = null, 
            string includeProperties = "")
        {
            IQueryable<T> query = _entity;
            
            if (whereCondicion != null)
            {
                query.Where(whereCondicion);
            }
            foreach (var includeProperty in includeProperties.Split(new char[]
                    {','},StringSplitOptions.RemoveEmptyEntries))
            {
                query= query.Include(includeProperty);
                
            }
            if(ordeBy != null)
            {
                return await ordeBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
    }
}
/*
 Otra forma de hacerlo es la sigueinte  con uso de lamda
using WaterSystem.Infrastructure.Commons.Bases;
using WaterSystem.Infrastructure.Persistences.Interfaces;
using System.Linq.Dynamic.Core;
using WaterSystem.Infrastructure.Helpers;
using WaterSystem.Infrastructure.Commons.Bases.Request;
using System.Linq.Expressions;

namespace WaterSystem.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
       
        protected IQueryable<TDto> OrderingAndPaginating<TDto>(BasePaginationRequest request, IQueryable<TDto> queryable) where TDto : class
        {
            
            var parameterExpression = Expression.Parameter(typeof(TDto), "x");
            var orderByProperty = Expression.Property(parameterExpression, request.Sort);    
            var convertedOrderByProperty = Expression.Convert(orderByProperty, typeof(object));
            var orderByExpression = Expression.Lambda<Func<TDto, object>>(convertedOrderByProperty, parameterExpression);
            IQueryable<TDto> queryDto;
            if (request.Order == "desc")
            {
                queryDto = queryable.OrderByDescending(orderByExpression);
            }
            else
            {
                queryDto = queryable.OrderBy(orderByExpression);
            }
            if (request.NumPage > 0 && request.NumRecordsPage > 0)
            {
                queryDto = queryDto.Skip((request.NumPage - 1) * request.NumRecordsPage)
                                   .Take(request.NumRecordsPage);
            }

            return queryDto;
        }
    }



}
 */
