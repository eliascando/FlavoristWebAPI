using System.Text;
using Domain;
using Domain.DTOs;
using Application.Interfaces;
using Infraestructure.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Infraestructure.Data.Context;

namespace Application.Services
{
    public class AuthorizationService 
        : IServiceAuthorization<Usuario, AuthResultDTO>
    {
        public IConfiguration _configuration;

        public AuthorizationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        CatalogoServiceUsuarioTipo CrearServicioCatalogo()
        {
            DBContext dB = new DBContext();
            CatalogoRepositoryUsuarioTipo repo = new CatalogoRepositoryUsuarioTipo(dB);
            CatalogoServiceUsuarioTipo servicio = new CatalogoServiceUsuarioTipo(repo);
            return servicio;
        }


        public string GenerateToken(Usuario user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            string secret = _configuration["JWT:Secret"] ?? throw new Exception("No se pudo generar el token");
            
            var key = Encoding.ASCII.GetBytes(secret);

            var catalogo = CrearServicioCatalogo();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.Nombres} {user.Apellidos}"),
                    new Claim(ClaimTypes.Email, user.Correo),
                    new Claim(ClaimTypes.Role, catalogo.ObtenerPorId(user.UsuarioTipoID).Nombre)
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
        private LoginRepository bd;

        public LoginService(LoginRepository _bd)
        {
           bd = _bd;
        }

        public Usuario Login(AuthDTO user)
        {
            var usuario = bd.Login(user) ?? throw new Exception("Usuario no encontrado");

            if (!BCrypt.Net.BCrypt.Verify(user.Password, usuario.Password))
                throw new Exception("Contraseña incorrecta");

            return usuario;
        }
    }
}
