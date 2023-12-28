using System.Text;
using Domain.Entities;
using Domain.DTOs;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain.Interfaces.Repository;
using Domain.Entities.Catalog;

namespace Application.Services
{
    public class AuthorizationService 
        : IServiceAuthorization<Usuario, AuthResultDTO>
    {
        private IConfiguration _configuration;
        private IRepositoryBase<UsuarioTipo, int> _repoUsuarioTipo;

        public AuthorizationService(
            IConfiguration configuration,
            IRepositoryBase<UsuarioTipo, int> repoUsuarioTipo
        )
        {
            _configuration = configuration;
            _repoUsuarioTipo = repoUsuarioTipo;
        }

        public string GenerateToken(Usuario user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            string secret = _configuration["JWT:Secret"] ?? throw new Exception("No se pudo generar el token");
            
            var key = Encoding.ASCII.GetBytes(secret);

            var usuarioTipo = _repoUsuarioTipo.ObtenerPorId(user.UsuarioTipoID);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.Nombres} {user.Apellidos}"),
                    new Claim(ClaimTypes.Email, user.Correo),
                    new Claim(ClaimTypes.Role, _repoUsuarioTipo.ObtenerPorId(user.UsuarioTipoID).Nombre)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenGenerated = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tokenGenerated);
            return token;
        }
    }

    public class LoginService
        : IServiceLogin<AuthDTO, Usuario>
    {
        private IRepositoryAuthorization<AuthDTO, Usuario> _bd;

        public LoginService(IRepositoryAuthorization<AuthDTO, Usuario> bd)
        {
            _bd = bd;
        }

        public Usuario Login(AuthDTO user)
        {
            var usuario = _bd.Login(user) ?? throw new Exception("Usuario no encontrado");

            if (!BCrypt.Net.BCrypt.Verify(user.Password, usuario.Password))
                throw new Exception("Contraseña incorrecta");

            return usuario;
        }
    }
}
