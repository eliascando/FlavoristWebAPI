﻿using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Application.Services
{
    public class ComentarioService
        : IServiceComentario<Comentario,CommentDTO, Guid>
    {
        private readonly IRepositoryComentario<Comentario, Guid> _repository;
        private readonly IRepositoryBase<Notificacion, int, Guid> _notificacion;
        private readonly IRepositoryBase<Evento, int, Guid> _evento;

        public ComentarioService(
            IRepositoryComentario<Comentario, Guid> repository,
            IRepositoryBase<Notificacion, int, Guid> notificacion, 
            IRepositoryBase<Evento, int, Guid> evento
        )
        {
            _repository = repository;
            _notificacion = notificacion;
            _evento = evento;
        }

        public Comentario AgregarComentario(CommentDTO comentario)
        {
            try
            {
                int EventoTipoID = 2; //Nuevo Comentario

                var newComment = new Comentario()
                {
                    Id = Guid.NewGuid(),
                    ComentarioPadreID = comentario.ComentarioPadreID,
                    ReferenciaID = comentario.ReferenciaID,
                    Texto = comentario.Texto,
                    EventoTipoID = EventoTipoID
                };

                var evento = new Evento()
                {
                    Id = Guid.NewGuid(),
                    ReferenciaID = newComment.Id,
                    EventoTipoID = EventoTipoID,
                    EntidadTipoID = comentario.EntidadTipoID,
                    UsuarioID = comentario.UsuarioID,
                    FechaHora = DateTime.Now
                };


                newComment.EventoID = evento.Id;

                var notificacion = new Notificacion()
                {
                    Id = Guid.NewGuid(),
                    EventoID = evento.Id,
                    FechaHora = DateTime.Now
                };


                _evento.Agregar(evento);
                var guardado = _repository.Agregar(newComment);
                _notificacion.Agregar(notificacion);

                _evento.Guardar();
                _repository.Guardar();
                _notificacion.Guardar();

                return guardado;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void EliminarComentario(Guid id)
        {
            _repository.EliminarComentario(id);
            _repository.Guardar();
        }

        public List<Comentario> ObtenerComentariosPadres(Guid idPost)
        {
            return _repository.ObtenerComentariosPadres(idPost);
        }

        public List<Comentario> ObtenerComentariosHijos(Guid idComentarioPadre)
        {
            return _repository.ObtenerComentariosHijos(idComentarioPadre);
        }

        public List<CommentThreadsDTO> ObtenerComentariosHilosPost(Guid idPost)
        {
            var comentariosPadres = _repository.ObtenerComentariosPadres(idPost);

            var comentariosHilos = comentariosPadres.Select(comentarioPadre => new CommentThreadsDTO
            {
                ReferenciaID = comentarioPadre.ReferenciaID,
                ComentarioPadre = comentarioPadre,
                ComentariosHijos = ObtenerComentariosHijosDTO(comentarioPadre.Id)
            }).ToList();

            return comentariosHilos;
        }

        private List<CommentThreadsDTO> ObtenerComentariosHijosDTO(Guid idComentarioPadre)
        {
            var comentariosHijos = _repository.ObtenerComentariosHijos(idComentarioPadre);

            return comentariosHijos.Select(comentarioHijo => new CommentThreadsDTO
            {
                ReferenciaID = comentarioHijo.ReferenciaID,
                ComentarioPadre = comentarioHijo,
                ComentariosHijos = ObtenerComentariosHijosDTO(comentarioHijo.Id) // Llamada recursiva
            }).ToList();
        }
    }
}
