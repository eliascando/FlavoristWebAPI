using Microsoft.AspNetCore.Mvc;
using Domain;
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
            RecetaPasoRepository repoRecetaPaso = new RecetaPasoRepository(db);
            RecetaIngredienteRepository repoRecetaIngrediente = new RecetaIngredienteRepository(db);

            PostService servicio = new PostService(repo, repoRecetaPaso, repoRecetaIngrediente);
            return servicio;
        }

        // GET: api/<PostController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            return null; //new string[] { "value1", "value2" };
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

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
