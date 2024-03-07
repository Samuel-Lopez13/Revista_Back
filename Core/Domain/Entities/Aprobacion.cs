using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Aprobacion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Aprobacion_Id { get; set; }
    public bool Aprobado { get; set; }
    public int Articulo_Id { get; set; }
    
    public virtual Articulo? Articulos { get; set; }
}