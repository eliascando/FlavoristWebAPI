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
        private readonly IConfiguration _configuration;
        private readonly AuthorizationService _authorizationService;
        private readonly LoginService _loginService;
        private readonly CatalogoServiceUsuarioTipo _catalogoServiceUsuarioTipo;

        public AuthorizationController(
            IConfiguration configuration,
            AuthorizationService authorizationService,
            LoginService loginService,
            CatalogoServiceUsuarioTipo catalogoServiceUsuarioTipo)
        {
            _configuration = configuration;
            _authorizationService = authorizationService;
            _loginService = loginService;
            _catalogoServiceUsuarioTipo = catalogoServiceUsuarioTipo;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<AuthResultDTO> Post([FromBody] AuthDTO loginDTO)
        {
            if (loginDTO == null)
                return BadRequest("Login no válido.");

            try
            {
                var usuario = _loginService.Login(loginDTO);
                var token = _authorizationService.GenerateToken(usuario);

                var usuarioTipo = _catalogoServiceUsuarioTipo.ObtenerPorId(usuario.UsuarioTipoID).Nombre;

                var resultado = new AuthResultDTO()
                {
                    Id = usuario.Id,
                    NombresCompletos = usuario.Nombres + " " + usuario.Apellidos,
                    Correo = usuario.Correo,
                    UsuarioTipo = usuarioTipo,
                    Token = token,
                };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { error = true, message = ex.Message }));
            }
        }
    }
}
