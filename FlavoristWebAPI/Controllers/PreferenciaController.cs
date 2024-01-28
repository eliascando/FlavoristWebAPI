using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using FlavoristWebAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlavoristWebAPI.Controllers
{
    [Route("api/guardar")]
    [ApiController]
    public class PreferenciaController : ControllerBase
    {
        private readonly PreferenciaCategoriaService _categoria;
        private readonly PreferenciaRecetaService _receta;
        private readonly IWebHostEnvironment _env;

        public PreferenciaController(PreferenciaCategoriaService categoria, PreferenciaRecetaService receta, IWebHostEnvironment env)
        {
            _categoria = categoria;
            _receta = receta;
            _env = env;
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
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
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
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        // Eliminar receta favorita
        [HttpDelete("/api/eliminar/recetaguardada/{idReceta}/{idUsuario}")]
        public ActionResult<Object> DeleteReceta(Guid idReceta, Guid idUsuario)
        {
            try
            {
                _receta.EliminarPorUsuarioYReceta(idUsuario, idReceta);
                return Ok(new { succed = true, message = "Receta eliminada!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        // Eliminar categoria favorita
        [HttpDelete("/api/eliminar/categoriaguardada/{idCategoria}/{idUsuario}")]
        public ActionResult<Object> DeleteCategoria(Guid idCategoria, Guid idUsuario)
        {
            try
            {
                _categoria.EliminarPorUsuarioYRecetaCategoria(idUsuario, idCategoria);
                return Ok(new { succed = true, message = "Categoria eliminada!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
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
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
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
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }
    }
}
