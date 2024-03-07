using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Rol
{
    public Rol()
    {
        Usuarios = new HashSet<Usuario>();
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Rol_Id { get; set; }

    public string Descripcion { get; set; } = null!;
    
    public virtual ICollection<Usuario> Usuarios { get; set; }
}