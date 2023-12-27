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
        PostService CrearServicio()
        {
            DBContext db = new DBContext();

            PostRepository repo = new PostRepository(db);
            EventoRepository repoEvento = new EventoRepository(db);
            NotificacionRepository repoNotificacion = new NotificacionRepository(db);
            PublicacionRepository repoPublicacion = new PublicacionRepository(db);


            PostService servicio = new PostService(repo, repoEvento, repoNotificacion, repoPublicacion);
            return servicio;
        }

        //Obtener por usuario
        [HttpGet("usuario/{idUser}")]
        public ActionResult GetPorUser(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ListarPorUsuario(id));
        }

        [HttpGet("categoria/{idCategoria}")]
        public ActionResult GetPorCategoria(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ListarPorCategoria(id));
        }

        //Obtener por id
        [HttpGet("{id}")]
        public ActionResult GetPorID(Guid id)
        {
            var servicio = CrearServicio();
            var respuesta = servicio.ObtenerPorId(id);
            return Ok(respuesta);
        }

        //Publicar receta
        [HttpPost]
        public ActionResult Post([FromBody] Receta receta)
        {
            try
            {
                var servicio = CrearServicio();
                var respuesta = servicio.Agregar(receta);
                return Ok(receta);
            }
            catch(Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { succed = false, message = ex.Message, details = ex }));
            }
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
