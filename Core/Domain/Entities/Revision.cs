using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Revision
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Revision_Id { get; set; }
    public TimeSpan FechaRevision { get; set; }
    public string ConstanciaRevision { get; set; }
    public int? AsignacionRevision_Id { get; set; }
    public int? Valoracion_Id { get; set; }
    public int? CriteriosEvaluacion_Id { get; set; }
    
    public virtual AsignacionRevision? AsignacionRevisiones { get; set; }
    public virtual Valoracion? Valoraciones { get; set; }
    public virtual CriterioEvaluacion? Criterios { get; set; }
}