using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class CriterioEvaluacion
{
    public CriterioEvaluacion()
    {
        Revisiones = new HashSet<Revision>();
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CriterioEvaluacion_Id { get; set; }
    public int Originalidad { get; set; }
    public int Calificacion { get; set; }
    public string Novedad { get; set; }
    public string Innovacion { get; set; }
    public string Relevancia { get; set; }
    public string Pertinencia { get; set; }
    public string Transcendencia { get; set; }
    public string Calidad { get; set; }
    public string Presentacion { get; set; }
    public string Comentario { get; set; }
    
    public virtual ICollection<Revision> Revisiones { get; set; }
}