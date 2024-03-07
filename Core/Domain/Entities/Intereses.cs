using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Intereses
{
    public Intereses()
    {
        Revisors = new HashSet<Revisor>();
        Articulos = new HashSet<Articulo>();
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Intereses_Id { get; set; }

    public string Descripcion { get; set; } = null!;
    
    public virtual ICollection<Revisor> Revisors { get; set; }
    public virtual ICollection<Articulo> Articulos { get; set; }
}