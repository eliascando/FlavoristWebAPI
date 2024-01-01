using Application.Interfaces;
using Domain.Entities.Catalog;
using Domain.Interfaces.Repository;

namespace Application.Services
{
    public class CatalogoServicePais
        : IServiceBase<Pais, int, Guid>
    {
        private readonly IRepositoryBase<Pais, int, Guid> _reposPais;

        public CatalogoServicePais(IRepositoryBase<Pais, int, Guid> reposPais)
        {
            _reposPais = reposPais;
        }

        public Pais Agregar(Pais entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("Pais", "No se puede agregar un pais nulo");

            entidad.Id = Guid.NewGuid();
            var usuario = _reposPais.Agregar(entidad);
            _reposPais.Guardar();
            return usuario;
        }

        public Pais Editar(Pais entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Pais entidad)
        {
            throw new NotImplementedException();
        }

        public List<Pais> Listar()
        {
            return _reposPais.Listar();
        }

        public Pais ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Pais ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoServiceUsuarioTipo
        : IServiceBase<UsuarioTipo, int, Guid>
    {
           private readonly IRepositoryBase<UsuarioTipo, int, Guid> _reposUsuarioTipo;

        public CatalogoServiceUsuarioTipo(IRepositoryBase<UsuarioTipo, int, Guid> reposUsuarioTipo)
        {
            _reposUsuarioTipo = reposUsuarioTipo;
        }

        public UsuarioTipo Agregar(UsuarioTipo entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("UsuarioTipo", "No se puede agregar un usuario tipo nulo");

            var usuarioTipo = _reposUsuarioTipo.Agregar(entidad);
            _reposUsuarioTipo.Guardar();
            return usuarioTipo;
        }

        public UsuarioTipo Editar(UsuarioTipo entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(UsuarioTipo entidad)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioTipo> Listar()
        {
            return _reposUsuarioTipo.Listar();
        }

        public UsuarioTipo ObtenerPorId(int id)
        {
            var resultado = _reposUsuarioTipo.ObtenerPorId(id) ?? throw new Exception("UsuarioTipo no encontrado");
            return resultado;
        }

        public UsuarioTipo ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoServiceIngredienteCategoria
        : IServiceBase<IngredienteCategoria, int, Guid>
    {
        private readonly IRepositoryBase<IngredienteCategoria, int, Guid> _reposIngredienteCategoria;

        public CatalogoServiceIngredienteCategoria(IRepositoryBase<IngredienteCategoria, int, Guid> reposIngredienteCategoria)
        {
            _reposIngredienteCategoria = reposIngredienteCategoria;
        }

        public IngredienteCategoria Agregar(IngredienteCategoria entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("IngredienteCategoria", "No se puede agregar un ingrediente categoria nulo");

            entidad.Id = Guid.NewGuid();
            var ingredienteCategoria = _reposIngredienteCategoria.Agregar(entidad);
            _reposIngredienteCategoria.Guardar();
            return ingredienteCategoria;
        }

        public IngredienteCategoria Editar(IngredienteCategoria entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(IngredienteCategoria entidad)
        {
            throw new NotImplementedException();
        }

        public List<IngredienteCategoria> Listar()
        {
            return _reposIngredienteCategoria.Listar();
        }

        public IngredienteCategoria ObtenerPorId(Guid id)
        {
            var resultado = _reposIngredienteCategoria.ObtenerPorId(id) ?? throw new Exception("IngredienteCategoria no encontrado");
            return resultado;
        }

        public IngredienteCategoria ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoServiceRecetaCategoria
        : IServiceBase<RecetaCategoria, int, Guid>
    {
        private readonly IRepositoryBase<RecetaCategoria, int, Guid> _reposRecetaCategoria;

        public CatalogoServiceRecetaCategoria(IRepositoryBase<RecetaCategoria, int, Guid> reposRecetaCategoria)
        {
            _reposRecetaCategoria = reposRecetaCategoria;
        }

        public RecetaCategoria Agregar(RecetaCategoria entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("RecetaCategoria", "No se puede agregar un receta categoria nulo");

            entidad.Id = Guid.NewGuid();
            var recetaCategoria = _reposRecetaCategoria.Agregar(entidad);
            _reposRecetaCategoria.Guardar();
            return recetaCategoria;
        }

        public RecetaCategoria Editar(RecetaCategoria entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(RecetaCategoria entidad)
        {
            throw new NotImplementedException();
        }

        public List<RecetaCategoria> Listar()
        {
            return _reposRecetaCategoria.Listar();
        }

        public RecetaCategoria ObtenerPorId(Guid id)
        {
            var resultado = _reposRecetaCategoria.ObtenerPorId(id) ?? throw new Exception("RecetaCategoria no encontrado");
            return resultado;
        }

        public RecetaCategoria ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoServiceRecetaDificultad
        : IServiceBase<RecetaDificultad, int, Guid>
    {
        private readonly IRepositoryBase<RecetaDificultad, int, Guid> _reposRecetaDificultad;

        public CatalogoServiceRecetaDificultad(IRepositoryBase<RecetaDificultad, int, Guid> reposRecetaDificultad)
        {
            _reposRecetaDificultad = reposRecetaDificultad;
        }

        public RecetaDificultad Agregar(RecetaDificultad entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("RecetaDificultad", "No se puede agregar un receta dificultad nulo");

            var recetaDificultad = _reposRecetaDificultad.Agregar(entidad);
            _reposRecetaDificultad.Guardar();
            return recetaDificultad;
        }

        public RecetaDificultad Editar(RecetaDificultad entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(RecetaDificultad entidad)
        {
            throw new NotImplementedException();
        }

        public List<RecetaDificultad> Listar()
        {
            return _reposRecetaDificultad.Listar();
        }

        public RecetaDificultad ObtenerPorId(int id)
        {
            var resultado = _reposRecetaDificultad.ObtenerPorId(id) ?? throw new Exception("RecetaDificultad no encontrado");
            return resultado;
        }

        public RecetaDificultad ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoServiceUnidadMedida
        : IServiceBase<UnidadMedida, int, Guid>
    {
        private readonly IRepositoryBase<UnidadMedida, int, Guid> _reposUnidadMedida;

        public CatalogoServiceUnidadMedida(IRepositoryBase<UnidadMedida, int, Guid> reposUnidadMedida)
        {
            _reposUnidadMedida = reposUnidadMedida;
        }

        public UnidadMedida Agregar(UnidadMedida entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("UnidadMedida", "No se puede agregar un unidad medida nulo");

            var unidadMedida = _reposUnidadMedida.Agregar(entidad);
            _reposUnidadMedida.Guardar();
            return unidadMedida;
        }

        public UnidadMedida Editar(UnidadMedida entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(UnidadMedida entidad)
        {
            throw new NotImplementedException();
        }

        public List<UnidadMedida> Listar()
        {
            return _reposUnidadMedida.Listar();
        }

        public UnidadMedida ObtenerPorId(int id)
        {
            var resultado = _reposUnidadMedida.ObtenerPorId(id) ?? throw new Exception("UnidadMedida no encontrado");
            return resultado;
        }

        public UnidadMedida ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoServiceEventoTipo
        : IServiceBase<EventoTipo, int, Guid>
    {
        private readonly IRepositoryBase<EventoTipo, int, Guid> _reposEventoTipo;

        public CatalogoServiceEventoTipo(IRepositoryBase<EventoTipo, int, Guid> reposEventoTipo)
        {
            _reposEventoTipo = reposEventoTipo;
        }

        public EventoTipo Agregar(EventoTipo entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("EventoTipo", "No se puede agregar un evento tipo nulo");

            var eventoTipo = _reposEventoTipo.Agregar(entidad);
            _reposEventoTipo.Guardar();
            return eventoTipo;
        }

        public EventoTipo Editar(EventoTipo entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(EventoTipo entidad)
        {
            throw new NotImplementedException();
        }

        public List<EventoTipo> Listar()
        {
            return _reposEventoTipo.Listar();
        }

        public EventoTipo ObtenerPorId(int id)
        {
            var resultado = _reposEventoTipo.ObtenerPorId(id) ?? throw new Exception("EventoTipo no encontrado");
            return resultado;
        }

        public EventoTipo ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
