using Application.Services;
using Domain.Entities;
using Infraestructure.Data.Context;
using Infraestructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlavoristWebAPI.Controllers
{
    [Route("api/follow")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly FollowService _followService;

        public FollowController(FollowService followService)
        {
            _followService = followService;
        }

        [HttpGet("followers/{id}")]
        public ActionResult GetFollowers(Guid id)
        {
            return Ok(_followService.ObtenerSeguidores(id));
        }

        [HttpGet("following/{id}")]
        public ActionResult GetFollowing(Guid id)
        {
            return Ok(_followService.ObtenerSeguidos(id));
        }

        [HttpPost]
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
    }
}
