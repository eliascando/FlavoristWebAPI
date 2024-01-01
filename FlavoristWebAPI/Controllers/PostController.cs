using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Services;
using Domain.DTOs;

namespace FlavoristWebAPI.Controllers
{
    //Esta clase es para publicar las recetas de los usuarios
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        //Obtener por usuario
        [HttpGet("usuario/{idUser}")]
        public ActionResult<List<Receta>> GetPorUser(Guid idUser)
        {
            try
            {
                return Ok(_postService.ListarPorUsuario(idUser));
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        [HttpGet("categoria/{idCategoria}")]
        public ActionResult<List<Receta>> GetPorCategoria(Guid idCategoria)
        {
            try
            {
                return Ok(_postService.ListarPorCategoria(idCategoria));
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        //Obtener por seguidos, es decir el feed de un usuario
        [HttpGet("feed/{idUsuario}")]
        public ActionResult<List<RecetaDTO>> GetFeed(Guid idUsuario)
        {
            try
            {
                return Ok(_postService.ListarRecetasFeed(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        //Obtener por id
        [HttpGet("{idReceta}")]
        public ActionResult<Receta> GetPorID(Guid idReceta)
        {
            var respuesta = _postService.ObtenerPorId(idReceta);
            return Ok(respuesta);
        }

        //Publicar receta
        [HttpPost]
        public ActionResult<Receta> Post([FromBody] Receta receta)
        {
            try
            {
                var respuesta = _postService.Agregar(receta);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

        //// Editar receta
        [HttpPut("actualizar")]
        public ActionResult<Object> Put([FromBody] Receta receta)
        {
            if (receta == null)
                return BadRequest("Debe enviar una receta válida.");
            try
            {
                _postService.Editar(receta);
                return Ok(new { succed = true, message = "Receta actualizada correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }


        //Eliminar receta
        [HttpDelete("{id}")]
        public ActionResult<Object> Delete(Guid id)
        {
            try
            {
                _postService.Eliminar(id);
                return Ok(new { succed = true, message = "Receta eliminada" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }
    }
}
