using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using FlavoristWebAPI.Utils;

namespace FlavoristWebAPI.Controllers
{
    [Route("api/notificacion")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        private readonly ObtenerNotificacionService _obtenerNotificacionService;
        private readonly IWebHostEnvironment _env;

        public NotificacionController(ObtenerNotificacionService obtenerNotificacionService, IWebHostEnvironment env)
        {
            _obtenerNotificacionService = obtenerNotificacionService;
            _env = env;
        }

        // Obtener notificaciones de un usuario
        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<List<NotificacionDTO>>> Get(Guid idUsuario)
        {
            try
            {
                var respuesta = await _obtenerNotificacionService.ObtenerNotificaciones(idUsuario);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new ExceptionResponse(ex, _env.IsDevelopment()));
            }
        }

    }
}
