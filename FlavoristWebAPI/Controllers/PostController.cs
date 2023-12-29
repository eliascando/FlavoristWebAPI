using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Services;

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
        public ActionResult GetPorUser(Guid idUser)
        {
            return Ok(_postService.ListarPorUsuario(idUser));
        }

        [HttpGet("categoria/{idCategoria}")]
        public ActionResult GetPorCategoria(Guid idCategoria)
        {
            return Ok(_postService.ListarPorCategoria(idCategoria));
        }

        //Obtener por id
        [HttpGet("{idReceta}")]
        public ActionResult GetPorID(Guid idReceta)
        {
            var respuesta = _postService.ObtenerPorId(idReceta);
            return Ok(respuesta);
        }

        //Publicar receta
        [HttpPost]
        public ActionResult Post([FromBody] Receta receta)
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

        //// TODO: Implementar PUT para editar receta
        //[HttpPut("{id}")]

        //Eliminar receta
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
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
