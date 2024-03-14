using System.ComponentModel.DataAnnotations;
using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Usuario.Command;

public record CrearUsuarioCommand : IRequest
{
    [Required]      
    public string Nombre { get; set; }
    
    [Required]
    [EmailAddress]
    public string Correo { get; set; }
    
    [Required]
    [MinLength(8)]
    public string Contrasena { get; set; }
    
    [Required]
    public string Pais { get; set; }
    
    [Required]
    public string Afiliacion { get; set; }
}

public class CrearUsuarioCommandHandler : IRequestHandler<CrearUsuarioCommand>
{
    private readonly RevistaContext _context;
    
    public CrearUsuarioCommandHandler(RevistaContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
    {
        //Se busca si no existe algun usuario con la cuenta
        var validar = await _context.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Correo == request.Correo);

        if (validar != null)
        {
            throw new BadRequestException("Error ya existe un usuario con ese correo");
        }
        
        var usuario = new Domain.Entities.Usuario()
        {
            Nombre = request.Nombre,
            Correo = request.Correo,
            Contrasena = BCrypt.Net.BCrypt.HashPassword(request.Contrasena),
            Pais = request.Pais,
            Afiliacion = request.Afiliacion,
            Rol_Id = 1
        };

        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
        
        return Unit.Value;
    }
}
