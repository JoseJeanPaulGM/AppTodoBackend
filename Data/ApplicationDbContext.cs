using Microsoft.EntityFrameworkCore;//// Para usar DbContext y DbSet
using TdoTareasBackend.Models;


namespace TdoTareasBackend.Data
{ // ApplicationDbContext hereda de DbContext, que es la clase principal de Entity Framework
    // para interactuar con la base de datos
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)// Llamamos al constructor de la clase base DbContext
        
        {

        }
   
        public DbSet<Tareas> Tareas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<Tareas>(b =>
            {
                b.ToTable("Tareas"); 
            });
        }
    }

}
    



