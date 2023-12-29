using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlavoristWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly FollowService _followService;

        public FollowController(FollowService followService)
        {
            _followService = followService;
        }

        // Obtener seguidores de un usuario
        [HttpGet("followers/{idUser}")]
        public ActionResult GetFollowers(Guid idUser)
        {
            return Ok(_followService.ObtenerSeguidores(idUser));
        }

        // Obtener seguidos de un usuario
        [HttpGet("following/{idUser}")]
        public ActionResult GetFollowing(Guid idUser)
        {
            return Ok(_followService.ObtenerSeguidos(idUser));
        }

        // Seguir a un usuario
        [HttpPost("follow")]
        public ActionResult Post([FromBody] Follow follow)
        {
            try
            {
                var respuesta = _followService.Agregar(follow);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Dejar de seguir a un usuario
        [HttpDelete("unfollow/{idSeguidor}/{idSeguido}")]
        public ActionResult Delete(Guid idSeguidor, Guid idSeguido)
        {
            try
            {
                _followService.EliminarPorSeguidorYSeguido(idSeguidor, idSeguido);
                return Ok(new { succed = true, message = "Follow eliminado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }
    }
}
