using Microsoft.AspNetCore.Mvc;
using System;
using Domain;
using Application.Services;
using Infraestructure;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // POST api/<UsuarioController>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Debe enviar un usuario válido.");

            var servicio = CrearServicio();
            var respuesta = servicio.Agregar(usuario);
            return Ok(usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("actualizar/{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Debe enviar un usuario válido.");

            if(id != usuario.Id)
                return BadRequest("El id del usuario no coincide con el id de la URL.");

            var servicio = CrearServicio();
            var respuesta = servicio.Editar(usuario);
            return Ok("Usuario actualizado correctamente.");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            var usuario = servicio.ObtenerPorId(id);
            servicio.Eliminar(usuario);
            return Ok("Usuario eliminado correctamente.");
        }
    }
}
