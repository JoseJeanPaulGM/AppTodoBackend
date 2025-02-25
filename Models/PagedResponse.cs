namespace TdoTareasBackend.Models
{
    // 1.3 Modelo para respuesta paginada
    public class PagedResponse<T>
    {
        // Lista de elementos en la página actual
        public List<T> Items { get; set; }

        // Información de paginación
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        // Propiedades de navegación
        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;
    }
}
