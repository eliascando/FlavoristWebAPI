using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System.Diagnostics;

namespace Application.Services
{
    public class PostService
        : IServicePost<Receta, Guid>
    {
        private IRepositoryPost<Receta, Guid> _repository;
        private IRepositoryBase<Evento,Guid> _evento;
        private IRepositoryBase<Notificacion,Guid> _notificacion;
        private IRepositoryBase<Publicacion,Guid> _publicacion;

        public PostService(
            IRepositoryPost<Receta, Guid> repository,
            IRepositoryBase<Evento,Guid> repoEvento,
            IRepositoryBase<Notificacion,Guid> repoNotificacion,
            IRepositoryBase<Publicacion,Guid> repoPublicacion

        )
        {
            _repository = repository;
            _evento = repoEvento;
            _notificacion = repoNotificacion;
            _publicacion = repoPublicacion;
        }

        public Receta Agregar(Receta entidad)
        {
            //Nueva Publicacion, EventoTipoID = 3
            if (entidad == null)
                throw new ArgumentNullException("Receta", "No se puede agregar una receta nula");
            try
            {
                entidad.Id = Guid.NewGuid();
                entidad.FechaCreacion = System.DateTime.Now;

                entidad.RecetaPasos.ForEach(paso => {
                    if (paso == null)
                        throw new ArgumentNullException("RecetaPaso", "No se puede agregar un paso nulo");

                    paso.Id = Guid.NewGuid();
                    paso.RecetaID = entidad.Id;
                    paso.Orden = entidad.RecetaPasos.IndexOf(paso) + 1;
                });

                entidad.RecetaIngredientes.ForEach(ingrediente =>
                {
                    if (ingrediente == null)
                        throw new ArgumentNullException("RecetaIngrediente", "No se puede agregar un ingrediente nulo");

                    ingrediente.Id = Guid.NewGuid();
                    ingrediente.RecetaID = entidad.Id;
                });


                var evento = new Evento()
                {
                    Id = Guid.NewGuid(),
                    EventoTipoID = 3,
                    UsuarioID = entidad.UsuarioID,
                    FechaHora = System.DateTime.Now,
                };

                var notificacion = new Notificacion()
                {
                    Id = Guid.NewGuid(),
                    EventoTipoID = 3,
                    ReferenciaID = entidad.Id,
                    FechaHora = System.DateTime.Now,
                };

                var publicacion = new Publicacion()
                {
                    Id = Guid.NewGuid(),
                    ReferenciaID = entidad.Id,
                    EventoTipoID = 3,
                    EventoID = evento.Id,
                };

                var resultado =_repository.Agregar(entidad);
                _publicacion.Agregar(publicacion);
                _evento.Agregar(evento);
                _notificacion.Agregar(notificacion);

                //Guardar cambios
                _publicacion.Guardar();
                _evento.Guardar();
                _notificacion.Guardar();
                _repository.Guardar();

                //Retornar resultado
                return resultado;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("Error al agregar la receta");
            }
        }

        public List<Receta> ListarPorCategoria(Guid id)
        {
            var resultado = _repository.ListarPorCategoria(id);
            return resultado;
        }

        public List<Receta> ListarPorIngrediente(Guid id)
        {
            var resultado = _repository.ListarPorIngrediente(id);
            return resultado;
        }

        public List<Receta> ListarPorUsuario(Guid id)
        {
            var resultado = _repository.ListarPorUsuario(id);
            return resultado;
        }

        public Receta ObtenerPorId(Guid id)
        {
            var resultado = _repository.ObtenerPorId(id);
            return resultado;
        }

        public Receta Editar(Receta entidad)
        {
            var resultado = _repository.Editar(entidad);
            return resultado;
        }

        public void Guardar()
        {
            _repository.Guardar();
        }
    }
}
