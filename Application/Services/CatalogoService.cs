using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Catalog;
using Domain.Interfaces.Repository;

namespace Application.Services
{
    public class CatalogoServicePais
        : IServiceBase<Pais, Guid>
    {
        private readonly IRepositoryBase<Pais, Guid> _reposPais;

        public CatalogoServicePais(IRepositoryBase<Pais, Guid> reposPais)
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
    }

    public class CatalogoServiceUsuarioTipo
        :IServiceBase<UsuarioTipo, int>
    {
           private readonly IRepositoryBase<UsuarioTipo, int> _reposUsuarioTipo;

        public CatalogoServiceUsuarioTipo(IRepositoryBase<UsuarioTipo, int> reposUsuarioTipo)
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
    }

    public class CatalogoServiceIngredienteCategoria
        :IServiceBase<IngredienteCategoria, Guid>
    {
        private readonly IRepositoryBase<IngredienteCategoria, Guid> _reposIngredienteCategoria;

        public CatalogoServiceIngredienteCategoria(IRepositoryBase<IngredienteCategoria, Guid> reposIngredienteCategoria)
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
    }

    public class CatalogoServiceRecetaCategoria
        :IServiceBase<RecetaCategoria, Guid>
    {
        private readonly IRepositoryBase<RecetaCategoria, Guid> _reposRecetaCategoria;

        public CatalogoServiceRecetaCategoria(IRepositoryBase<RecetaCategoria, Guid> reposRecetaCategoria)
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
    }

    public class CatalogoServiceRecetaDificultad
        :IServiceBase<RecetaDificultad, int>
    {
        private readonly IRepositoryBase<RecetaDificultad, int> _reposRecetaDificultad;

        public CatalogoServiceRecetaDificultad(IRepositoryBase<RecetaDificultad, int> reposRecetaDificultad)
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
    }

    public class CatalogoServiceUnidadMedida
        :IServiceBase<UnidadMedida, int>
    {
        private readonly IRepositoryBase<UnidadMedida, int> _reposUnidadMedida;

        public CatalogoServiceUnidadMedida(IRepositoryBase<UnidadMedida, int> reposUnidadMedida)
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
    }

    public class CatalogoServiceEventoTipo
        :IServiceBase<EventoTipo, int>
    {
        private readonly IRepositoryBase<EventoTipo, int> _reposEventoTipo;

        public CatalogoServiceEventoTipo(IRepositoryBase<EventoTipo, int> reposEventoTipo)
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
    }
}
