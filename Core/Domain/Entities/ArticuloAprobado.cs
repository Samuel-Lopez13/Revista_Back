using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class ArticuloAprobado
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ArticuloAprobado_Id { get; set; }
    public string? Constancia { get; set; }
    public int Articulo_Id { get; set; }
    
    public virtual Articulo? Articulos { get; set; }
}