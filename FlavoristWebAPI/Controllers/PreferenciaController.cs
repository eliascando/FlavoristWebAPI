using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlavoristWebAPI.Controllers
{
    [Route("api/guardar")]
    [ApiController]
    public class PreferenciaController : ControllerBase
    {
        private readonly PreferenciaCategoriaService _categoria;
        private readonly PreferenciaRecetaService _receta;

        public PreferenciaController(PreferenciaCategoriaService categoria, PreferenciaRecetaService receta)
        {
            _categoria = categoria;
            _receta = receta;
        }

        // Guardar receta favorita
        [HttpPost("receta")]
        public ActionResult<Object> Post([FromBody] UsuarioRecetaFav entidad)
        {
            if (entidad == null)
                return BadRequest("Debe enviar un usuario válido.");
            try
            {
                var respuesta = _receta.Agregar(entidad);
                return Ok(new { succed = true, message = "Receta guardada!", usuario = respuesta });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message });
            }
        }

        // Guardar categoria favorita
        [HttpPost("categoria")]
        public ActionResult<Object> Post([FromBody] UsuarioRecetaCategoriaFav entidad)
        {
            if (entidad == null)
                return BadRequest("Debe enviar un usuario válido.");
            try
            {
                var respuesta = _categoria.Agregar(entidad);
                return Ok(new { succed = true, message = "Categoria guardada!", usuario = respuesta });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message });
            }
        }

        // Eliminar receta favorita
        [HttpDelete("/api/eliminar/recetaguardada")]
        public ActionResult<Object> DeleteReceta(UsuarioRecetaFav entidad)
        {
            try
            {
                _receta.Eliminar(entidad);
                return Ok(new { succed = true, message = "Receta eliminada!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message });
            }
        }

        // Eliminar categoria favorita
        [HttpDelete("/api/eliminar/categoriaguardada")]
        public ActionResult<Object> DeleteCategoria(UsuarioRecetaCategoriaFav entidad)
        {
            try
            {
                _categoria.Eliminar(entidad);
                return Ok(new { succed = true, message = "Categoria eliminada!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message });
            }
        }

        // Obtener recetas favoritas de un usuario
        [HttpGet("/api/recetasguardadas/{idUsuario}")]
        public ActionResult<List<UsuarioRecetaFav>> GetRecetas(Guid idUsuario)
        {
            try
            {
                var respuesta = _receta.ObtenerPreferenciasPorUsuario(idUsuario);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message });
            }
        }

        // Obtener categorias favoritas de un usuario
        [HttpGet("/api/categoriasguardadas/{idUsuario}")]
        public ActionResult<List<UsuarioRecetaCategoriaFav>> GetCategorias(Guid idUsuario)
        {
            try
            {
                var respuesta = _categoria.ObtenerPreferenciasPorUsuario(idUsuario);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message });
            }
        }
    }
}
