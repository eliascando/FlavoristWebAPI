using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace FlavoristWebAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_usuarioService.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(Guid id)
        {
            return Ok(_usuarioService.ObtenerPorId(id));
        }

        [HttpPost("crear")]
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
                return BadRequest(new { succed = false, message = ex.Message });
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
        public ActionResult Delete(Guid id)
        {
            var usuario = _usuarioService.ObtenerPorId(id);
            _usuarioService.Eliminar(usuario);
            return Ok(new { succed = true, message = "Usuario eliminado correctamente." });
        }
    }
}
