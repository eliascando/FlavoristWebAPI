using Microsoft.AspNetCore.Mvc;
using System;
using Domain;
using Application.Services;
using Infraestructure;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;

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
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Usuario no válido.");

            var servicio = CrearServicio();
            var respuesta = servicio.Agregar(usuario);
            return Ok(usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
