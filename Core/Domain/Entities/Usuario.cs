using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Usuario
{
    public Usuario()
    {
        Revisors = new HashSet<Revisor>();
        Articulos = new HashSet<Articulo>();
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Usuario_Id { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Contrasena { get; set; }
    public string Pais { get; set; }
    public string Afiliacion { get; set; }
    public int Rol_Id { get; set; } 
    
    public virtual Rol? Roles { get; set; }
    
    public virtual ICollection<Revisor> Revisors { get; set; }
    public virtual ICollection<Articulo> Articulos { get; set; }
}