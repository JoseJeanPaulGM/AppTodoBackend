using TdoTareasBackend.Models;

namespace TdoTareasBackend.Services
{
    public interface ITareasService
    {
        Task<IEnumerable<Tareas>> GetAllTareasAsync();
        Task<Tareas> GetTareaByIdAsync(int id);
        Task<Tareas> CreateTareaAsync(Tareas tarea);
        Task<bool> UpdateTareaAsync(int id, Tareas tarea);
        Task<bool> DeleteTareaAsync(int id);
        Task<IEnumerable<Tareas>> GetTareasByCompletionAsync(bool isComplete);
       
    }
}
