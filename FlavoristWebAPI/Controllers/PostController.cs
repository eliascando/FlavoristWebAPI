using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Services;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public ActionResult GetPorUser(Guid id)
        {
            return Ok(_postService.ListarPorUsuario(id));
        }

        [HttpGet("categoria/{idCategoria}")]
        public ActionResult GetPorCategoria(Guid id)
        {
            return Ok(_postService.ListarPorCategoria(id));
        }

        //Obtener por id
        [HttpGet("{id}")]
        public ActionResult GetPorID(Guid id)
        {
            var respuesta = _postService.ObtenerPorId(id);
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

        //// PUT api/<PostController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

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
