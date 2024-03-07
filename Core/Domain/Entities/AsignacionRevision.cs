using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class AsignacionRevision
{
    public AsignacionRevision()
    {
        Revisiones = new HashSet<Revision>();
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AsignacionRevision_Id { get; set; }
    public int Revisor_Id { get; set; }
    public int Articulo_Id { get; set; }
    
    public virtual Articulo? Articulos { get; set; }
    public virtual Revisor? Revisors { get; set; }
    
    public virtual ICollection<Revision> Revisiones { get; set; }
}