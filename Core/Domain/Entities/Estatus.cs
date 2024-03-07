using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Estatus
{
    public Estatus()
    {
        Articulos = new HashSet<Articulo>();
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Estatus_Id { get; set; }

    public string Descripcion { get; set; } = null!;
    
    public virtual ICollection<Articulo> Articulos { get; set; }
}