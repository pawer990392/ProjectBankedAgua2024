using WaterSystem.Infrastructure.Commons.Bases.Request;

namespace WaterSystem.Infrastructure.Commons.Bases
{
    public static class EnumerableHelper
    {
        /*
            Esto puede tener implicaciones de rendimiento si estás trabajando con grandes
            conjuntos de datos, ya que se cargarán todos los elementos en memoria antes
            de aplicar la paginación.
         */
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> enumerable, BasePaginationRequest request)
        {
            return enumerable.Skip((request.NumPage - 1) * request.Records).Take(request.Records);
        }
        

    }
}
