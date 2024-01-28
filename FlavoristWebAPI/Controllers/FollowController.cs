using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using FlavoristWebAPI.Utils;
namespace FlavoristWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly FollowService _followService;
        private readonly IWebHostEnvironment _env;

        public FollowController(FollowService followService, IWebHostEnvironment env)
        {
            _followService = followService;
            _env = env;
        }

        // Obtener seguidores de un usuario
        [HttpGet("followers/{idUser}")]
        public ActionResult<List<UserDTO>> GetFollowers(Guid idUser)
        {
            return Ok(_followService.ObtenerSeguidores(idUser));
        }

        // Obtener seguidos de un usuario
        [HttpGet("following/{idUser}")]
        public ActionResult<List<UserDTO>> GetFollowing(Guid idUser)
        {
            return Ok(_followService.ObtenerSeguidos(idUser));
        }

        // Seguir a un usuario
        [HttpPost("follow")]
        public ActionResult<Follow> Post([FromBody] Follow follow)
        {
            try
            {
                var respuesta = _followService.Agregar(follow);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

        // Dejar de seguir a un usuario
        [HttpDelete("unfollow/{idSeguidor}/{idSeguido}")]
        public ActionResult<Object> Delete(Guid idSeguidor, Guid idSeguido)
        {
            try
            {
                _followService.EliminarPorSeguidorYSeguido(idSeguidor, idSeguido);
                return Ok(new { succed = true, message = "Follow eliminado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }
    }
}
