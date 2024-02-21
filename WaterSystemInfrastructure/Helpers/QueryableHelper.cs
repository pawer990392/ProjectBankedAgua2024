using WaterSystem.Infrastructure.Commons.Bases.Request;

namespace WaterSystem.Infrastructure.Helpers
{
    public static class QueryableHelper
    {   
        //proveedores de consultas
        public static IQueryable<T>Paginate<T>(this IQueryable <T> queryable, BasePaginationRequest request)
        {
            /*
             Ayuda a reducir la cantidad de registros devueltos según el número de página y la cantidad
             de registros por página especificados en el objeto BasePaginationRequest.
             */
            //calcula cuántos registros deben omitirse para la página actual.
            //(request.NumPage-1)*request.Record
            //cuántos registros se deben devolver como resultado de la consulta de paginación.//
            //.Take(request.Record)
            return queryable.Skip((request.NumPage-1)*request.NumRecordsPage).Take(request.NumRecordsPage);
        }        
    }
}
