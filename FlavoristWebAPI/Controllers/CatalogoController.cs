using Application.Services;
using Domain;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [AllowAnonymous]
        public ActionResult<Pais> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
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
            return Ok(respuesta);
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
        [AllowAnonymous]
        public ActionResult<UsuarioTipo> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
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
            return Ok(respuesta);
        }
    }

    [Route("api/catalogo/ingredientecategoria")]
    [ApiController]
    public class CatalogoIngredienteCategoriaController : ControllerBase
    {
        CatalogoServiceIngredienteCategoria CrearServicio()
        {
            DBContext dB = new DBContext();
            CatalogoRepositoryIngredienteCategoria repo = new CatalogoRepositoryIngredienteCategoria(dB);
            CatalogoServiceIngredienteCategoria servicio = new CatalogoServiceIngredienteCategoria(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult<IngredienteCategoria> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<IngredienteCategoria> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] IngredienteCategoria ingredienteCategoria)
        {
            if (ingredienteCategoria == null)
                return BadRequest("IngredienteCategoria no válido.");

            var servicio = CrearServicio();
            var respuesta = servicio.Agregar(ingredienteCategoria);
            return Ok(respuesta);
        }
    }

    [Route("api/catalogo/recetacategoria")]
    [ApiController]
    public class CatalogoRecetaCategoriaController : ControllerBase
    {
        CatalogoServiceRecetaCategoria CrearServicio()
        {
            DBContext dB = new DBContext();
            CatalogoRepositoryRecetaCategoria repo = new CatalogoRepositoryRecetaCategoria(dB);
            CatalogoServiceRecetaCategoria servicio = new CatalogoServiceRecetaCategoria(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult<RecetaCategoria> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<RecetaCategoria> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] RecetaCategoria recetaCategoria)
        {
            if (recetaCategoria == null)
                return BadRequest("RecetaCategoria no válido.");

            var servicio = CrearServicio();
            var respuesta = servicio.Agregar(recetaCategoria);
            return Ok(respuesta);
        }
    }

    [Route("api/catalogo/recetadificultad")]
    [ApiController]
    public class CatalogoRecetaDificultadController : ControllerBase
    {
        CatalogoServiceRecetaDificultad CrearServicio()
        {
            DBContext dB = new DBContext();
            CatalogoRepositoryRecetaDificultad repo = new CatalogoRepositoryRecetaDificultad(dB);
            CatalogoServiceRecetaDificultad servicio = new CatalogoServiceRecetaDificultad(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult<RecetaDificultad> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<RecetaDificultad> Get(int id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] RecetaDificultad recetaDificultad)
        {
            if (recetaDificultad == null)
                return BadRequest("RecetaDificultad no válido.");

            var servicio = CrearServicio();
            var respuesta = servicio.Agregar(recetaDificultad);
            return Ok(respuesta);
        }
    }

    [Route("api/catalogo/unidadmedida")]
    [ApiController]
    public class CatalogoUnidadMedidaController : ControllerBase
    {
        CatalogoServiceUnidadMedida CrearServicio()
        {
            DBContext dB = new DBContext();
            CatalogoRepositoryUnidadMedida repo = new CatalogoRepositoryUnidadMedida(dB);
            CatalogoServiceUnidadMedida servicio = new CatalogoServiceUnidadMedida(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult<UnidadMedida> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<UnidadMedida> Get(int id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] UnidadMedida unidadMedida)
        {
            if (unidadMedida == null)
                return BadRequest("UnidadMedida no válido.");

            var servicio = CrearServicio();
            var respuesta = servicio.Agregar(unidadMedida);
            return Ok(respuesta);
        }
    }

    [Route("api/catalogo/eventotipo")]
    [ApiController]
    public class CatalogoEventoTipoController : ControllerBase
    {
        CatalogoServiceEventoTipo CrearServicio()
        {
            DBContext dB = new DBContext();
            CatalogoRepositoryEventoTipo repo = new CatalogoRepositoryEventoTipo(dB);
            CatalogoServiceEventoTipo servicio = new CatalogoServiceEventoTipo(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult<EventoTipo> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<EventoTipo> Get(int id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] EventoTipo eventoTipo)
        {
            if (eventoTipo == null)
                return BadRequest("EventoTipo no válido.");

            var servicio = CrearServicio();
            var respuesta = servicio.Agregar(eventoTipo);
            return Ok(respuesta);
        }
    }

    [Route("api/catalogo/entidadtipo")]
    [ApiController]
    public class CatalogoEntidadTipoController : ControllerBase
    {
        CatalogoServiceEntidadTipo CrearServicio()
        {
            DBContext dB = new DBContext();
            CatalogoRepositoryEntidadTipo repo = new CatalogoRepositoryEntidadTipo(dB);
            CatalogoServiceEntidadTipo servicio = new CatalogoServiceEntidadTipo(repo);
            return servicio;
        }

        [HttpGet]
        public ActionResult<EntidadTipo> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<EntidadTipo> Get(int id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] EntidadTipo entidadTipo)
        {
            if (entidadTipo == null)
                return BadRequest("EntidadTipo no válido.");

            var servicio = CrearServicio();
            var respuesta = servicio.Agregar(entidadTipo);
            return Ok(respuesta);
        }
    }
}
