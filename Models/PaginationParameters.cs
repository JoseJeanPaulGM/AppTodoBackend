namespace TdoTareasBackend.Models
{
    public class PaginationParameters
    {
        // Valor máximo permitido para tamaño de página
        const int maxPageSize = 50;

        // Valor predeterminado del tamaño de página
        private int _pageSize = 10;

        // Número de página (1-based)
        public int PageNumber { get; set; } = 1;

        // Tamaño de página con validación para no exceder el máximo
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}

