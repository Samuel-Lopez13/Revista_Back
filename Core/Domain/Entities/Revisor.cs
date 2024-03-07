using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Revisor
{
    public Revisor()
    {
        AsignacionRevisions = new HashSet<AsignacionRevision>();
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Revisor_Id { get; set; }
    public string Curriculum { get; set; }
    public int Usuario_Id { get; set; }
    public int? Intereses_Id { get; set; }
    
    public virtual Usuario? Usuarios { get; set; }
    public virtual Intereses? Intereses { get; set; }
    
    public virtual ICollection<AsignacionRevision> AsignacionRevisions { get; set; }
}