using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;
using Domain.Entities;
using Application.Services;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlavoristWebAPI.Controllers
{
    [Route("api/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        ComentarioService CrearServicio()
        {
            DBContext db = new DBContext();
            ComentarioRepository repository = new ComentarioRepository(db);
            NotificacionRepository notificacion = new NotificacionRepository(db);
            EventoRepository evento = new EventoRepository(db);
            ComentarioService servicio = new ComentarioService(repository, notificacion, evento);
            return servicio;
        }
        //// GET: api/<ComentarioController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ComentarioController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost("nuevo")]
        public ActionResult Post([FromBody] CommentDTO comment)
        {
            try
            {
                var respuesta = CrearServicio().AgregarComentario(comment);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { succed = false, message = ex.Message, details = ex }));
            }
        }

        [HttpDelete("eliminar/{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                CrearServicio().EliminarComentario(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { succed = false, message = ex.Message, details = ex }));
            }
        }

        [HttpGet("padres/{id}")]
        public ActionResult GetPadres(Guid id)
        {
            try
            {
                var respuesta = CrearServicio().ObtenerComentariosPadres(id);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { succed = false, message = ex.Message, details = ex }));
            }
        }

        [HttpGet("hijos/{id}")]
        public ActionResult GetHijos(Guid id)
        {
            try
            {
                var respuesta = CrearServicio().ObtenerComentariosHijos(id);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { succed = false, message = ex.Message, details = ex }));
            }
        }

        [HttpGet("hilos/{id}")] 
        public ActionResult GetHilos(Guid id)
        {
            try
            {
                var respuesta = CrearServicio().ObtenerComentariosHilosPost(id);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { succed = false, message = ex.Message, details = ex }));
            }
        }

        //// PUT api/<ComentarioController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ComentarioController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
