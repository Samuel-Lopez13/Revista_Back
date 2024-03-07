using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Valoracion
{
    public Valoracion()
    {
        Revisiones = new HashSet<Revision>();
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Valoracion_Id { get; set; }
    public string Descripcion { get; set; }
    
    public virtual ICollection<Revision> Revisiones { get; set; }
}