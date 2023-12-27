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
        FollowService CrearServicio()
        {
            DBContext db = new DBContext();
            FollowRepository followRepository = new FollowRepository(db);
            FollowsRepository followsRepository = new FollowsRepository(db);
            NotificacionRepository notificacionRepository = new NotificacionRepository(db);
            EventoRepository eventoRepository = new EventoRepository(db);

            FollowService servicio = new FollowService(followRepository, followsRepository, eventoRepository, notificacionRepository);
            return servicio;
        }

        [HttpGet("followers/{id}")]
        public ActionResult Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerSeguidores(id));
        }

        [HttpGet("following/{id}")]
        public ActionResult GetFollowing(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.ObtenerSeguidos(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Follow follow)
        {
            try
            {
                var servicio = CrearServicio();
                var respuesta = servicio.Agregar(follow);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
