using Microsoft.EntityFrameworkCore;
using TdoTareasBackend.Data;
using TdoTareasBackend.Models;

namespace TdoTareasBackend.Services

{
    public class TareaService : ITareasService
    {
        private readonly ApplicationDbContext _context;

        public TareaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tareas>> GetAllTareasAsync()
        {
            return await _context.Tareas.ToListAsync();
        }

        public async Task<Tareas> GetTareaByIdAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                throw new KeyNotFoundException($"Tarea con ID {id} no encontrada");
            return tarea;
        }

        public async Task<Tareas> CreateTareaAsync(Tareas tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return tarea;
        }

        public async Task<bool> UpdateTareaAsync(int id, Tareas tarea)
        {
            if (id != tarea.Id)
                throw new ArgumentException("ID no coincide");

            _context.Entry(tarea).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTareaAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
                return false;

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Tareas>> GetTareasByCompletionAsync(bool isComplete)
        {
            return await _context.Tareas
       .Where(t => t.IsComplete == isComplete)
       .ToListAsync();
        }
    }

    }
