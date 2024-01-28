using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Services;
using Domain.DTOs;
using FlavoristWebAPI.Utils;

namespace FlavoristWebAPI.Controllers
{
    //Esta clase es para publicar las recetas de los usuarios
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;
        private readonly LikeService _likeService;
        private readonly PreferenciaRecetaService _preferenciaRecetaService;
        private readonly IWebHostEnvironment _env;

        public PostController(PostService postService, IWebHostEnvironment env, LikeService likeService, PreferenciaRecetaService preferenciaRecetaService)
        {
            _postService = postService;
            _env = env;
            _likeService = likeService;
            _preferenciaRecetaService = preferenciaRecetaService;
        }

        //Obtener por usuario
        [HttpGet("usuario/{idUser}")]
        public ActionResult<List<Receta>> GetPorUser(Guid idUser)
        {
            try
            {
                return Ok(_postService.ListarPorUsuario(idUser));
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        [HttpGet("categoria/{idCategoria}")]
        public ActionResult<List<Receta>> GetPorCategoria(Guid idCategoria)
        {
            try
            {
                return Ok(_postService.ListarPorCategoria(idCategoria));
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        //Obtener por seguidos, es decir el feed de un usuario
        [HttpGet("feed/{idUsuario}")]
        public ActionResult<List<RecetaDTO>> GetFeed(Guid idUsuario)
        {
            try
            {
                return Ok(_postService.ListarRecetasFeed(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        [HttpGet("explorer/{idUsuario}")]
        public ActionResult<List<RecetaDTO>> GetExplorer(Guid idUsuario)
        {
            try
            {
                return Ok(_postService.ListarRecetasExplorer(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        //Obtener por id
        [HttpGet("{idReceta}/{idUsuario}")]
        public ActionResult<Object> GetPorID(Guid idReceta, Guid idUsuario)
        {
            var receta = _postService.ObtenerPorId(idReceta);
            if (receta == null)
                return NotFound();

            var tieneLike = _likeService.ExisteLikeDeUsuarioEnPost(idUsuario, idReceta);
            var guardado = _preferenciaRecetaService.ExistePreferencia(idUsuario, idReceta);

            var response = new
            {
                receta.Id,
                receta.UsuarioID,
                receta.Nombre,
                receta.Descripcion,
                receta.TiempoPreparacion,
                receta.Imagen,
                receta.FechaCreacion,
                receta.CategoriaID,
                receta.DificultadID,
                receta.Porciones,
                receta.Costo,
                receta.RecetaPasos,
                receta.RecetaIngredientes,
                TieneLike = tieneLike,
                Guardado = guardado
            };

            return Ok(response);
        }

        //Publicar receta
        [HttpPost]
        public ActionResult<Receta> Post([FromBody] Receta receta)
        {
            try
            {
                var respuesta = _postService.Agregar(receta);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        //// Editar receta
        [HttpPut("actualizar")]
        public ActionResult<Object> Put([FromBody] Receta receta)
        {
            if (receta == null)
                return BadRequest("Debe enviar una receta válida.");
            try
            {
                _postService.Editar(receta);
                return Ok(new { succed = true, message = "Receta actualizada correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }


        //Eliminar receta
        [HttpDelete("{id}")]
        public ActionResult<Object> Delete(Guid id)
        {
            try
            {
                _postService.Eliminar(id);
                return Ok(new { succed = true, message = "Receta eliminada" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }
    }
}
