using Core.Domain.Exceptions;
using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scrypt;

namespace Core.Features.Usuario.Command;

public record Login : IRequest<LoginResponse>
{
    public string Correo { get; set; }
    public string Contrasena { get; set; }
}

public class LoginHanlder : IRequestHandler<Login, LoginResponse>
{
    private readonly RevistaContext _context;
    private readonly IAuthService _authService;
    
    public LoginHanlder(RevistaContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }
    
    public async Task<LoginResponse> Handle(Login request, CancellationToken cancellationToken)
    {
        //Valida que no esten vacias
        if(string.IsNullOrEmpty(request.Correo) || string.IsNullOrEmpty(request.Contrasena))
            throw new BadRequestException("Correo y contraseña son obligatorios");

        var user = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Correo == request.Correo);
        
        var contrasena = BCrypt.Net.BCrypt.Verify(request.Contrasena, user.Contrasena) ? user.Contrasena : request.Contrasena;
        
        //Si cumple con las validaciones se procede a autenticar
        var token = await _authService.AuthenticateAsync(request.Correo, contrasena);
        
        if(token == null)
            throw new NotFoundException("Usuario no encontrado");
        
        //Lo necesitamos para saber su rol
        var usuario = await _context.Usuarios
            .AsNoTracking()
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(x => x.Correo == request.Correo);
        
        //Respuesta
        return new LoginResponse()
        {
            Token = token,
            Rol = usuario?.Roles.Descripcion ?? "Sin Rol"
        };
    }
}

public record LoginResponse
{
    public string Token { get; set; }
    public string Rol { get; set; }
}