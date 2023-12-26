using Application.Services;
using Domain;
using Infraestructure.Data;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlavoristWebAPI.Controllers
{
    [Route("api/catalogo/pais")]
    [ApiController]
    public class CatalogoPaisController : ControllerBase
    {
        CatalogoServicePais CrearServicio()
        {
            DBContext dB = new DBContext();
            CatalogoRepositoryPais repo = new CatalogoRepositoryPais(dB);
            CatalogoServicePais servicio = new CatalogoServicePais(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult<Pais> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<Pais> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Pais pais)
        {
            if (pais == null)
                return BadRequest("Pais no válido.");

            var servicio = CrearServicio();
            var respuesta = servicio.Agregar(pais);
            return Ok(pais);
        }
    }

    [Route("api/catalogo/usuariotipo")]
    [ApiController]
    public class CatalogoUsuarioTipoController : ControllerBase
    {
        CatalogoServiceUsuarioTipo CrearServicio()
        {
            DBContext dB = new DBContext();
            CatalogoRepositoryUsuarioTipo repo = new CatalogoRepositoryUsuarioTipo(dB);
            CatalogoServiceUsuarioTipo servicio = new CatalogoServiceUsuarioTipo(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult<UsuarioTipo> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioTipo> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioTipo usuarioTipo)
        {
            if (usuarioTipo == null)
                return BadRequest("UsuarioTipo no válido.");

            var servicio = CrearServicio();
            var respuesta = servicio.Agregar(usuarioTipo);
            return Ok(usuarioTipo);
        }
    }
}
