using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlavoristWebAPI.Controllers
{
    [Route("api/like")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly LikeService _likeService;

        public LikeController(LikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet("contar/{id}")]
        public ActionResult<Object> Get(Guid id)
        {
            var cantidad = _likeService.ObtenerCantidadLikeDePost(id);
            return Ok(new { succed = true, message = "Cantidad de likes", data = cantidad , idPost = id});
        }

        // Dar like a una receta
        [HttpPost("receta")]
        public ActionResult<Object> PostReceta([FromBody] LikeDTO like)
        {
            try
            {
                like.EntidadTipoID = 2; // Receta
                var respuesta = _likeService.DarLikeDesdeDTO(like);
                return Ok(new { succed = true, message = "Like agregado", data = respuesta });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        // Dar like a un comentario
        [HttpPost("comentario")]
        public ActionResult<Object> PostComentario([FromBody] LikeDTO like)
        {
            try
            {
                like.EntidadTipoID = 3; // Comentario
                var respuesta = _likeService.DarLikeDesdeDTO(like);
                return Ok(new { succed = true, message = "Like agregado", data = respuesta });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        // Borrar un like
        [HttpDelete("/api/unlike/{idUser}/{idPost}")]
        public ActionResult<Object> Delete(Guid idUser, Guid idPost)
        {
            try
            {
                bool resultado = _likeService.EliminarLikePorUsuarioYPost(idUser, idPost);
                if (resultado)
                    return Ok(new { succed = true, message = "Like eliminado" });
                else
                    return BadRequest(new { succed = false, message = "No se encontró el like" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        // Obtener usuarios que dieron like a un post
        [HttpGet("usuarios/{idPost}")]
        public ActionResult<List<UserDTO>> GetUsuarios(Guid idPost)
        {
            try
            {
                var respuesta = _likeService.ObtenerLikesOwners(idPost);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }
    }
}
