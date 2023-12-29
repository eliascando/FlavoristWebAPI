using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlavoristWebAPI.Controllers
{
    [Route("api/notificacion")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        private readonly ObtenerNotificacionService _obtenerNotificacionService;

        public NotificacionController(ObtenerNotificacionService obtenerNotificacionService)
        {
            _obtenerNotificacionService = obtenerNotificacionService;
        }

        // Obtener notificaciones de un usuario
        [HttpGet("{idUsuario}")]
        public ActionResult<List<NotificacionDTO>> Get(Guid idUsuario)
        {
            try
            {
                var respuesta = _obtenerNotificacionService.ObtenerNotificaciones(idUsuario);
                return Ok(new { succed = true, message = "Notificaciones obtenidas", data = respuesta.Result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { succed = false, message = ex.Message, details = ex });
            }
        }

    }
}
