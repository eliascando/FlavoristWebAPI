using Domain.DTOs;
using Domain.Interfaces.Repository;
using Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repository
{
    public class ObtenerNotificacionRepository
        : IRepositoryObtenerNotificacion<NotificacionDTO, Guid>
    {
        private readonly DBContext _context;

        public ObtenerNotificacionRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<NotificacionDTO>> ObtenerNotificaciones(Guid idUsuario)
        {
            var fechaNotificacionesUsuario = await _context.Usuarios
                .Where(u => u.Id == idUsuario)
                .Select(u => u.FechaNotificaciones)
                .FirstOrDefaultAsync();

            var notificaciones = await _context.Eventos
                .Where(ev => ev.FechaHora > fechaNotificacionesUsuario &&
                             (ev.UsuarioID != idUsuario ||
                              _context.Follows.Any(f => f.SeguidoID == ev.UsuarioID && f.SeguidorID == idUsuario)))
                .Select(ev => new
                {
                    ev.FechaHora,
                    Mensaje = _context.Likes.Any(l => l.EventoID == ev.Id && ev.UsuarioID != idUsuario) ?
                              _context.Usuarios.Where(u => u.Id == ev.UsuarioID)
                              .Select(u => u.Nombres + " " + u.Apellidos + " dio like a tu receta '" +
                                          _context.Recetas.FirstOrDefault(r => r.Id == _context.Likes.FirstOrDefault(l => l.EventoID == ev.Id).ReferenciaID).Nombre + "'.")
                              .FirstOrDefault()
                              :
                              _context.Comentarios.Any(coment => coment.EventoID == ev.Id && ev.UsuarioID != idUsuario) ?
                              _context.Usuarios.Where(u => u.Id == ev.UsuarioID)
                              .Select(u => u.Nombres + " " + u.Apellidos + " comentó en tu receta '" +
                                          _context.Recetas.FirstOrDefault(r => r.Id == _context.Comentarios.FirstOrDefault(coment => coment.EventoID == ev.Id).ReferenciaID).Nombre + "'.")
                              .FirstOrDefault()
                              :
                              _context.Publicaciones.Any(pub => pub.EventoID == ev.Id && _context.Follows.Any(f => f.SeguidorID == idUsuario && f.SeguidoID == ev.UsuarioID)) ?
                              _context.Usuarios.Where(u => u.Id == ev.UsuarioID)
                              .Select(u => u.Nombres + " " + u.Apellidos + " publicó una nueva receta '" +
                                          _context.Recetas.FirstOrDefault(r => r.Id == _context.Publicaciones.FirstOrDefault(pub => pub.EventoID == ev.Id).ReferenciaID).Nombre + "'.")
                              .FirstOrDefault()
                              :
                              _context.Follows.Any(follow => follow.EventoID == ev.Id && follow.SeguidorID != idUsuario) ?
                              _context.Usuarios.Where(u => u.Id == ev.UsuarioID)
                              .Select(u => u.Nombres + " " + u.Apellidos + " te ha seguido.")
                              .FirstOrDefault()
                              :
                              string.Empty
                })
                .Where(x => !string.IsNullOrEmpty(x.Mensaje))
                .OrderByDescending(x => x.FechaHora)
                .ToListAsync();
            
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == idUsuario);

            if (usuario != null)
            {
                usuario.FechaNotificaciones = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return notificaciones.Select(x => new NotificacionDTO
            {
                Mensaje = x.Mensaje,
                TiempoTranscurrido = ConvertirMinutosATexto((int)(DateTime.Now - x.FechaHora).TotalMinutes)
            }).ToList();
        }

        private string ConvertirMinutosATexto(int minutos)
        {
            if (minutos < 1)
            {
                return "Hace menos de un minuto";
            }
            else if (minutos < 60)
            {
                return $"Hace {minutos} minuto{(minutos > 1 ? "s" : "")}";
            }
            else if (minutos < 1440)
            {
                var horas = minutos / 60;
                return $"Hace {horas} hora{(horas > 1 ? "s" : "")}";
            }
            else
            {
                var dias = minutos / 1440;
                return $"Hace {dias} día{(dias > 1 ? "s" : "")}";
            }
        }

    }
}

