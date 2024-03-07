using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Articulo
{
    public Articulo()
    {
        ArticuloAprobados = new HashSet<ArticuloAprobado>();
        Aprobacions = new HashSet<Aprobacion>();
        AsignacionRevisions = new HashSet<AsignacionRevision>();
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Articulo_Id { get; set; }

    public string Titulo { get; set; } = null!;
    public TimeSpan Fecha { get; set; }
    public string Archivo { get; set; } = null!;
    public int? Usuario_Id { get; set; }
    public int? Intereses_Id { get; set; }
    public int? Estatus_Id { get; set; }
    
    public virtual Usuario? Usuarios { get; set; }
    public virtual Intereses? Interes { get; set; }
    public virtual Estatus? status { get; set; }
    
    public virtual ICollection<ArticuloAprobado> ArticuloAprobados { get; set; }
    public virtual ICollection<Aprobacion> Aprobacions { get; set; }
    public virtual ICollection<AsignacionRevision> AsignacionRevisions { get; set; }
}