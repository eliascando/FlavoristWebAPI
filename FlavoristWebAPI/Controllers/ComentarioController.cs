using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;
using Application.Services;
using Domain.Entities;
using FlavoristWebAPI.Utils;

namespace FlavoristWebAPI.Controllers
{
    [Route("api/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly ComentarioService _comentarioService;
        private readonly IWebHostEnvironment _env;

        public ComentarioController(ComentarioService comentarioService, IWebHostEnvironment env)
        {
            _comentarioService = comentarioService;
            _env = env;
        }

        // Comentar receta
        [HttpPost("/api/comentar/receta")]
        public ActionResult<Object> PostReceta([FromBody] CommentDTO comment)
        {
            try
            {
                comment.EntidadTipoID = 2; // Receta
                var respuesta = _comentarioService.AgregarComentario(comment);
                return Ok(new { succed = true, message = "Comentario agregado", data = respuesta });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        // Comentar comentario
        [HttpPost("/api/comentar/comentario")]
        public ActionResult<Object> PostComentario([FromBody] CommentDTO comment)
        {
            try
            {
                comment.EntidadTipoID = 3; // Comentario
                var respuesta = _comentarioService.AgregarComentario(comment);
                return Ok(new { succed = true, message = "Comentario agregado", data = respuesta });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        // Eliminar comentario
        [HttpDelete("eliminar/{idComentario}")]
        public ActionResult<Object> Delete(Guid idComentario)
        {
            try
            {
                _comentarioService.EliminarComentario(idComentario);
                return Ok(new { succed = true, message = "Comentario eliminado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex));
            }
        }

        // Obtener comentarios PADRES de un post
        [HttpGet("padres/{idPost}")]
        public ActionResult<List<Comentario>> GetPadres(Guid idPost)
        {
            try
            {
                var respuesta = _comentarioService.ObtenerComentariosPadres(idPost);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        // Obtener comentarios HIJOS de un comentario
        [HttpGet("hijos/{idComentario}")]
        public ActionResult<List<Comentario>> GetHijos(Guid idComentario)
        {
            try
            {
                var respuesta = _comentarioService.ObtenerComentariosHijos(idComentario);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        // Obtener hilos de un post
        [HttpGet("hilos/{idPost}")] 
        public ActionResult<List<CommentThreadsDTO>> GetHilos(Guid idPost)
        {
            try
            {
                var respuesta = _comentarioService.ObtenerComentariosHilosPost(idPost);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }
    }
}
