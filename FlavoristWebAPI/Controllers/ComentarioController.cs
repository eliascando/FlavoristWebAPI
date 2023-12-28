using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;
using Domain.Entities;
using Application.Services;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;
using Newtonsoft.Json;

namespace FlavoristWebAPI.Controllers
{
    [Route("api/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ComentarioService _comentarioService;

        public ComentarioController(ComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        [HttpPost("nuevo")]
        public ActionResult Post([FromBody] CommentDTO comment)
        {
            try
            {
                var respuesta = _comentarioService.AgregarComentario(comment);
                return Ok(new { succed = true, message = "Comentario agregado", data = respuesta });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        [HttpDelete("eliminar/{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _comentarioService.EliminarComentario(id);
                return Ok(JsonConvert.SerializeObject(new { succed = true, message = "Comentario eliminado" }));
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
                var respuesta = _comentarioService.ObtenerComentariosPadres(id);
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
                var respuesta = _comentarioService.ObtenerComentariosHijos(id);
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
                var respuesta = _comentarioService.ObtenerComentariosHilosPost(id);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { succed = false, message = ex.Message, details = ex }));
            }
        }
    }
}
