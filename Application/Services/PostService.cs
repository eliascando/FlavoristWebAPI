using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Entities.Catalog;
using Domain.Interfaces.Repository;
using System.Diagnostics;

namespace Application.Services
{
    public class PostService
        : IServicePost<Receta, Guid>
    {
        private readonly IRepositoryPost<Receta, Guid> _repository;
        private readonly IRepositoryBase<Evento, int, Guid> _evento;
        private readonly IRepositoryBase<Notificacion, int, Guid> _notificacion;
        private readonly IRepositoryBase<Publicacion, int, Guid> _publicacion;
        private readonly IRepositoryBase<RecetaCategoria, int, Guid> _categoria;
        private readonly IRepositoryBase<RecetaDificultad, int, Guid> _dificultad;

        public PostService(
            IRepositoryPost<Receta, Guid> repository,
            IRepositoryBase<Evento, int, Guid> repoEvento,
            IRepositoryBase<Notificacion, int, Guid> repoNotificacion,
            IRepositoryBase<Publicacion, int, Guid> repoPublicacion,
            IRepositoryBase<RecetaCategoria, int, Guid> repoCategoria,
            IRepositoryBase<RecetaDificultad, int, Guid> repoDificultad
        )
        {
            _repository = repository;
            _evento = repoEvento;
            _notificacion = repoNotificacion;
            _publicacion = repoPublicacion;
            _categoria = repoCategoria;
            _dificultad = repoDificultad;
        }

        public Receta Agregar(Receta entidad)
        {
            int EventoTipoID = 3; //Nueva Receta
            int EntidadTipoID = 2; //Receta

            if (entidad == null)
                throw new ArgumentNullException("Receta", "No se puede agregar una receta nula");
            try
            {
                entidad.Id = Guid.NewGuid();
                entidad.FechaCreacion = DateTime.Now;

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
                    ReferenciaID = entidad.Id,
                    EventoTipoID = EventoTipoID,
                    EntidadTipoID = EntidadTipoID,
                    UsuarioID = entidad.UsuarioID,
                    FechaHora = DateTime.Now,
                };

                var notificacion = new Notificacion()
                {
                    Id = Guid.NewGuid(),
                    EventoID = evento.Id,
                    FechaHora = DateTime.Now,
                };

                var publicacion = new Publicacion()
                {
                    Id = Guid.NewGuid(),
                    ReferenciaID = entidad.Id,
                    EventoTipoID = EventoTipoID,
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
            return _repository.ListarPorCategoria(id); ;
        }

        public List<Receta> ListarPorIngrediente(Guid id)
        {
            return _repository.ListarPorIngrediente(id); ;
        }

        public List<Receta> ListarPorUsuario(Guid id)
        {
            return _repository.ListarPorUsuario(id);
        }

        public Receta ObtenerPorId(Guid id)
        {
            return _repository.ObtenerPorId(id);
        }

        public Receta Editar(Receta entidad)
        {
            return _repository.Editar(entidad);
        }

        public void Eliminar(Guid id)
        {
            _repository.Eliminar(id);
        }

        public void Guardar()
        {
            _repository.Guardar();
        }

        public List<Receta> ListorPorSeguidos(Guid idUsuario)
        {
            throw new NotImplementedException();
        }
        public List<RecetaDTO> ListarRecetasFeed(Guid idUsuario)
        {
            var recetas = _repository.ListorPorSeguidos(idUsuario);
            var recetasDTO = new List<RecetaDTO>();

            recetas.ForEach(receta =>
            {
                recetasDTO.Add(new RecetaDTO()
                {
                    Id = receta.Id,
                    Nombre = receta.Nombre,
                    Descripcion = receta.Descripcion,
                    Imagen = receta.Imagen,
                    FechaCreacion = receta.FechaCreacion,
                    Categoria = _categoria.ObtenerPorId(receta.CategoriaID).Nombre,
                    Dificultad = _dificultad.ObtenerPorId(receta.DificultadID).Nombre,
                    Porciones = receta.Porciones,
                    Costo = receta.Costo,
                });
            });

            return recetasDTO;
        }

        public List<RecetaDTO> ListarRecetasExplorer(Guid idUsuario)
        {
            var recetas = _repository.ListarExplorer(idUsuario);
            var recetasDTO = new List<RecetaDTO>();
            recetas.ForEach( receta =>
            {   
                recetasDTO.Add(new RecetaDTO()
                {
                    Id = receta.Id,
                    Nombre = receta.Nombre,
                    Descripcion = receta.Descripcion,
                    Imagen = receta.Imagen,
                    FechaCreacion = receta.FechaCreacion,
                    Categoria = _categoria.ObtenerPorId(receta.CategoriaID).Nombre,
                    Dificultad = _dificultad.ObtenerPorId(receta.DificultadID).Nombre,
                    Porciones = receta.Porciones,
                    Costo = receta.Costo,
                });
            });   
            return recetasDTO;
        }

        public List<Receta> ListarExplorer(Guid idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
