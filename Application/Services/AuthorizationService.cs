using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.DTOs;
using Application.Interfaces;
using Application.Services;
using Infraestructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BCrypt.Net;
using System.Diagnostics;
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

            Debug.WriteLine(secret);

            var key = Encoding.ASCII.GetBytes(secret);

            var servicio = CrearServicioCatalogo();
            //var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]) ?? throw new Exception("No se pudo generar el token");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.Nombres} {user.Apellidos}"),
                    new Claim(ClaimTypes.Email, user.Correo),
                    new Claim(ClaimTypes.Role, servicio.ObtenerPorId(user.UsuarioTipoID).Nombre)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenGenerated = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tokenGenerated);
            return token;
        }

        //public AuthResultDTO ValidateToken(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    string secret = _configuration["JWT:Secret"] ?? throw new Exception("No se pudo generar el token");

        //    Debug.WriteLine(secret);

        //    var key = Encoding.ASCII.GetBytes(secret);

        //    Debug.WriteLine(key);
        //    //var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]) ?? throw new Exception("No se pudo generar el token");

        //    var validationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(key),
        //        ValidateLifetime = true,
        //        ValidateAudience = false,
        //        ValidateIssuer = false
        //    };

        //    SecurityToken validatedToken;
        //    try
        //    {
        //        tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Token inválido");
        //    }

        //    var jwtToken = (JwtSecurityToken)validatedToken;
        

        //    return new AuthResultDTO
        //    {
        //        Id = Guid.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value),
        //        NombresCompletos = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value,
        //        Correo = jwtToken.Claims.First(x => x.Type == ClaimTypes.Email).Value,
        //        UsuarioTipo = jwtToken.Claims.First(x => x.Type == ClaimTypes.Role).Value,
        //        Token = token
        //    };
        //}
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
