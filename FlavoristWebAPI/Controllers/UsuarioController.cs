using Microsoft.AspNetCore.Mvc;
using Domain;
using Application.Services;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace FlavoristWebAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuarioService CrearServicio()
        {
            DBContext dB = new DBContext();
            UsuarioRepository repo = new UsuarioRepository(dB);
            UsuarioService servicio = new UsuarioService(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorId(id));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    return BadRequest("Debe enviar un usuario válido.");

                var servicio = CrearServicio();
                var respuesta = servicio.Agregar(usuario);
                return Ok(JsonConvert.SerializeObject(new { succed = true, message = "Usuario creado correctamente.", usuario = respuesta }));
            }
            catch (System.Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { succed = false, message = ex.Message }));
            }
        }

        [HttpPut("actualizar/{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Debe enviar un usuario válido.");

            if(id != usuario.Id)
                return BadRequest("El id del usuario no coincide con el id de la URL.");

            var servicio = CrearServicio();
            servicio.Editar(usuario);
            return Ok(JsonConvert.SerializeObject(new { succed = true, message = "Usuario actualizado correctamente." }));
        }

        [HttpDelete("eliminar/{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            var usuario = servicio.ObtenerPorId(id);
            servicio.Eliminar(usuario);
            return Ok(JsonConvert.SerializeObject(new { succed = true, message = "Usuario eliminado correctamente." }));
        }
    }
}
