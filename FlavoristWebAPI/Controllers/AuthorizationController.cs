using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;
using Infraestructure.Data.Context;
using Application.Services;
using Infraestructure.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlavoristWebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public IConfiguration configuration { get; }

        public AuthorizationController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        AuthorizationService CrearServicio()
        {
            AuthorizationService servicio = new AuthorizationService(configuration);
            return servicio;

        }
        LoginService CrearServicioLogin()
        {
            DBContext dB = new DBContext();
            LoginRepository repo = new LoginRepository(dB);
            LoginService servicio = new LoginService(repo);
            return servicio;
        }
        CatalogoServiceUsuarioTipo CrearServicioUsuarioTipo()
        {
            DBContext dB = new DBContext();
            CatalogoRepositoryUsuarioTipo repo = new CatalogoRepositoryUsuarioTipo(dB);
            CatalogoServiceUsuarioTipo servicio = new CatalogoServiceUsuarioTipo(repo);
            return servicio;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<AuthResultDTO> Post([FromBody] AuthDTO loginDTO)
        {
            if (loginDTO == null)
                return BadRequest("Login no válido.");

            try
            {
                var _serviceAuthorization = CrearServicio();
                var _serviceLogin = CrearServicioLogin();

                var usuario = _serviceLogin.Login(loginDTO);
                var token = _serviceAuthorization.GenerateToken(usuario);

                var servicioUsuarioTipo = CrearServicioUsuarioTipo();
                var usuarioTipo = servicioUsuarioTipo.ObtenerPorId(usuario.UsuarioTipoID).Nombre;

                var resultado = new AuthResultDTO()
                {
                    Id = usuario.Id,
                    NombresCompletos = usuario.Nombres + " " + usuario.Apellidos,
                    Correo = usuario.Correo,
                    UsuarioTipo = usuarioTipo,
                    Token = token,
                };

                return Ok(resultado);

            }catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { error = true, message = ex.Message }));
            }
        }
    }
}
