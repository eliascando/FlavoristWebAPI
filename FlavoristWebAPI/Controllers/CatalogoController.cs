using Application.Services;
using Domain;
using Infraestructure.Data;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlavoristWebAPI.Controllers
{
    [Route("api/catalogo")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        CatalogoService CrearServicio()
        {
            DBContext dB = new DBContext();
            CatalogoRepository repo = new CatalogoRepository(dB);
            CatalogoService servicio = new CatalogoService(repo);
            return servicio;
        }

        #region PaisCatalogo
        // GET: api/<CatalogoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CatalogoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CatalogoController>
        [HttpPost("/pais")]
        public ActionResult Post([FromBody] Pais pais)
        {
            if (pais == null)
                return BadRequest("Pais no válido.");

            var servicio = CrearServicio();
            var respuesta = servicio.Agregar(pais);
            return Ok(pais);
        }

        // PUT api/<CatalogoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CatalogoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
        #endregion
    }
}
