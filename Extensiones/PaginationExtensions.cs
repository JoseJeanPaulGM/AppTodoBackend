using TdoTareasBackend.Models;

namespace TdoTareasBackend.Extensiones
{
    public static class PaginationExtensions

    {
        // Método de extensión para convertir IQueryable en respuesta paginada
        public static PagedResponse<T> ToPagedResponse<T>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            // Obtener el número total de elementos
            var count = source.Count();

            // Aplicar Skip y Take para obtener solo los elementos de la página actual
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Crear y devolver la respuesta paginada con todos los datos necesarios
            return new PagedResponse<T>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
        }
    };
        }
