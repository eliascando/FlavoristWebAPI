using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Domain.DTOs;
using FlavoristWebAPI.Utils;

namespace FlavoristWebAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly IWebHostEnvironment _env;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Obtener información detallada de un usuario, solo para administradores
        [HttpGet("/admin/usuario/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult<Usuario> Get(Guid id)
        {
            return Ok(_usuarioService.ObtenerPorId(id));
        }

        // Obtener información de un usuario, para todos los usuarios
        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUsuario(Guid id)
        {
            return Ok(_usuarioService.ObtenerUsuarioDTO(id));
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    return BadRequest("Debe enviar un usuario válido.");

                var respuesta = _usuarioService.Agregar(usuario);
                return Ok(new { succed = true, message = "Usuario creado correctamente.", usuario = respuesta });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        [HttpPut("actualizar/{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Debe enviar un usuario válido.");

            if (id != usuario.Id)
                return BadRequest("El id del usuario no coincide con el id de la URL.");

            _usuarioService.Editar(usuario);
            return Ok(new { succed = true, message = "Usuario actualizado correctamente." });
        }

        [HttpDelete("eliminar/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult Delete(Guid id)
        {
            var usuario = _usuarioService.ObtenerPorId(id);
            _usuarioService.Eliminar(usuario);
            return Ok(new { succed = true, message = "Usuario eliminado correctamente." });
        }
    }
}
