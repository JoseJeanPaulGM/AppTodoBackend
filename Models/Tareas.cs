using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace TdoTareasBackend.Models
{
    [Table("Tareas")]
    public class Tareas
    {
            [Key]                                 
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
            public int Id { get; set; }

            [Required]                             // Campo obligatorio
            [StringLength(100)]                    // Longitud máxima
            public string? Title { get; set; }

            [StringLength(500)]                   
            public string? Description { get; set; }

            public bool IsComplete { get; set; }
        }
    }

