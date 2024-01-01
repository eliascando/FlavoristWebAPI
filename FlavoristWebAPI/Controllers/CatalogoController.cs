using Application.Services;
using Domain.Entities.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlavoristWebAPI.Controllers
{
    // Estos son los catalogos
    [Route("api/catalogo/pais")]
    [ApiController]
    public class CatalogoPaisController : ControllerBase
    {
        private readonly CatalogoServicePais _catalogoServicePais;

        public CatalogoPaisController(CatalogoServicePais catalogoServicePais)
        {
            _catalogoServicePais = catalogoServicePais;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<Pais> Get()
        {
            return Ok(_catalogoServicePais.Listar());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Pais> Get(Guid id)
        {
            return Ok(_catalogoServicePais.ObtenerPorId(id));
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")] // Se agrega la politica "OnlyAdmin
        public ActionResult Post([FromBody] Pais pais)
        {
            if (pais == null)
                return BadRequest("Pais no válido.");

            var respuesta = _catalogoServicePais.Agregar(pais);
            return Ok(respuesta);
        }
    }

    [Route("api/catalogo/ingredientecategoria")]
    [ApiController]
    public class CatalogoIngredienteCategoriaController : ControllerBase
    {
        private readonly CatalogoServiceIngredienteCategoria _catalogoServiceIngredienteCategoria;

        public CatalogoIngredienteCategoriaController(CatalogoServiceIngredienteCategoria catalogoServiceIngredienteCategoria)
        {
            _catalogoServiceIngredienteCategoria = catalogoServiceIngredienteCategoria;
        }

        [HttpGet]
        public ActionResult<IngredienteCategoria> Get()
        {
            return Ok(_catalogoServiceIngredienteCategoria.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<IngredienteCategoria> Get(Guid id)
        {
            return Ok(_catalogoServiceIngredienteCategoria.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] IngredienteCategoria ingredienteCategoria)
        {
            if (ingredienteCategoria == null)
                return BadRequest("IngredienteCategoria no válido.");

            var respuesta = _catalogoServiceIngredienteCategoria.Agregar(ingredienteCategoria);
            return Ok(respuesta);
        }
    }

    [Route("api/catalogo/recetacategoria")]
    [ApiController]
    public class CatalogoRecetaCategoriaController : ControllerBase
    {
        private readonly CatalogoServiceRecetaCategoria _catalogoServiceRecetaCategoria;

        public CatalogoRecetaCategoriaController(CatalogoServiceRecetaCategoria catalogoServiceRecetaCategoria)
        {
            _catalogoServiceRecetaCategoria = catalogoServiceRecetaCategoria;
        }

        [HttpGet]
        public ActionResult<RecetaCategoria> Get()
        {
            return Ok(_catalogoServiceRecetaCategoria.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<RecetaCategoria> Get(Guid id)
        {
            return Ok(_catalogoServiceRecetaCategoria.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] RecetaCategoria recetaCategoria)
        {
            if (recetaCategoria == null)
                return BadRequest("RecetaCategoria no válido.");

            var respuesta = _catalogoServiceRecetaCategoria.Agregar(recetaCategoria);
            return Ok(respuesta);
        }
    }

    [Route("api/catalogo/recetadificultad")]
    [ApiController]
    public class CatalogoRecetaDificultadController : ControllerBase
    {
        private readonly CatalogoServiceRecetaDificultad _catalogoServiceRecetaDificultad;

        public CatalogoRecetaDificultadController(CatalogoServiceRecetaDificultad catalogoServiceRecetaDificultad)
        {
            _catalogoServiceRecetaDificultad = catalogoServiceRecetaDificultad;
        }

        [HttpGet]
        public ActionResult<RecetaDificultad> Get()
        {
            return Ok(_catalogoServiceRecetaDificultad.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<RecetaDificultad> Get(int id)
        {
            return Ok(_catalogoServiceRecetaDificultad.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] RecetaDificultad recetaDificultad)
        {
            if (recetaDificultad == null)
                return BadRequest("RecetaDificultad no válido.");

            var respuesta = _catalogoServiceRecetaDificultad.Agregar(recetaDificultad);
            return Ok(respuesta);
        }
    }

    [Route("api/catalogo/unidadmedida")]
    [ApiController]
    public class CatalogoUnidadMedidaController : ControllerBase
    {
        private readonly CatalogoServiceUnidadMedida _catalogoServiceUnidadMedida;

        public CatalogoUnidadMedidaController(CatalogoServiceUnidadMedida catalogoServiceUnidadMedida)
        {
            _catalogoServiceUnidadMedida = catalogoServiceUnidadMedida;
        }

        [HttpGet]
        public ActionResult<UnidadMedida> Get()
        {
            return Ok(_catalogoServiceUnidadMedida.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<UnidadMedida> Get(int id)
        {
            return Ok(_catalogoServiceUnidadMedida.ObtenerPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] UnidadMedida unidadMedida)
        {
            if (unidadMedida == null)
                return BadRequest("UnidadMedida no válido.");

            var respuesta = _catalogoServiceUnidadMedida.Agregar(unidadMedida);
            return Ok(respuesta);
        }
    }

    #region NO SE USA
    //[Route("api/catalogo/eventotipo")]
    //[ApiController]
    //public class CatalogoEventoTipoController : ControllerBase
    //{
    //    private readonly CatalogoServiceEventoTipo _catalogoServiceEventoTipo;

    //    public CatalogoEventoTipoController(CatalogoServiceEventoTipo catalogoServiceEventoTipo)
    //    {
    //        _catalogoServiceEventoTipo = catalogoServiceEventoTipo;
    //    }

    //    [HttpGet]
    //    public ActionResult<EventoTipo> Get()
    //    {
    //        return Ok(_catalogoServiceEventoTipo.Listar());
    //    }

    //    [HttpGet("{id}")]
    //    public ActionResult<EventoTipo> Get(int id)
    //    {
    //        return Ok(_catalogoServiceEventoTipo.ObtenerPorId(id));
    //    }

    //    [HttpPost]
    //    public ActionResult Post([FromBody] EventoTipo eventoTipo)
    //    {
    //        if (eventoTipo == null)
    //            return BadRequest("EventoTipo no válido.");

    //        var respuesta = _catalogoServiceEventoTipo.Agregar(eventoTipo);
    //        return Ok(respuesta);
    //    }
    //}

    //[Route("api/catalogo/usuariotipo")]
    //[ApiController]
    //public class CatalogoUsuarioTipoController : ControllerBase
    //{
    //    private readonly CatalogoServiceUsuarioTipo _catalogoServiceUsuarioTipo;

    //    public CatalogoUsuarioTipoController(CatalogoServiceUsuarioTipo catalogoServiceUsuarioTipo)
    //    {
    //        _catalogoServiceUsuarioTipo = catalogoServiceUsuarioTipo;
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public ActionResult<UsuarioTipo> Get()
    //    {
    //        return Ok(_catalogoServiceUsuarioTipo.Listar());
    //    }

    //    [HttpGet("{id}")]
    //    [AllowAnonymous]
    //    public ActionResult<UsuarioTipo> Get(int id)
    //    {
    //        return Ok(_catalogoServiceUsuarioTipo.ObtenerPorId(id));
    //    }

    //    [HttpPost]
    //    public ActionResult Post([FromBody] UsuarioTipo usuarioTipo)
    //    {
    //        if (usuarioTipo == null)
    //            return BadRequest("UsuarioTipo no válido.");

    //        var respuesta = _catalogoServiceUsuarioTipo.Agregar(usuarioTipo);
    //        return Ok(respuesta);
    //    }
    //}
    #endregion
}
