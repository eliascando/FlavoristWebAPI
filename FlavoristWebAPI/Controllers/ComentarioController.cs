using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;
using Application.Services;

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

        // Comentar receta
        [HttpPost("/api/comentar/receta")]
        public ActionResult PostReceta([FromBody] CommentDTO comment)
        {
            try
            {
                comment.EntidadTipoID = 2; // Receta
                var respuesta = _comentarioService.AgregarComentario(comment);
                return Ok(new { succed = true, message = "Comentario agregado", data = respuesta });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        // Comentar comentario
        [HttpPost("/api/comentar/comentario")]
        public ActionResult PostComentario([FromBody] CommentDTO comment)
        {
            try
            {
                comment.EntidadTipoID = 3; // Comentario
                var respuesta = _comentarioService.AgregarComentario(comment);
                return Ok(new { succed = true, message = "Comentario agregado", data = respuesta });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        // Eliminar comentario
        [HttpDelete("eliminar/{idComentario}")]
        public ActionResult Delete(Guid idComentario)
        {
            try
            {
                _comentarioService.EliminarComentario(idComentario);
                return Ok(new { succed = true, message = "Comentario eliminado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        // Obtener comentarios PADRES de un post
        [HttpGet("padres/{idPost}")]
        public ActionResult GetPadres(Guid idPost)
        {
            try
            {
                var respuesta = _comentarioService.ObtenerComentariosPadres(idPost);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        // Obtener comentarios HIJOS de un comentario
        [HttpGet("hijos/{idComentario}")]
        public ActionResult GetHijos(Guid idComentario)
        {
            try
            {
                var respuesta = _comentarioService.ObtenerComentariosHijos(idComentario);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        // Obtener hilos de un post
        [HttpGet("hilos/{idPost}")] 
        public ActionResult GetHilos(Guid idPost)
        {
            try
            {
                var respuesta = _comentarioService.ObtenerComentariosHilosPost(idPost);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }
    }
}
