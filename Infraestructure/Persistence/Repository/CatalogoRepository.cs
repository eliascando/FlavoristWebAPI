using Domain.Entities.Catalog;
using Domain.Interfaces.Repository;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repository
{
    public class CatalogoRepositoryPais
        : IRepositoryBase<Pais, int, Guid>
    {
        private DBContext db;

        public CatalogoRepositoryPais(DBContext _db)
        {
            db = _db;
        }

        public Pais Agregar(Pais entidad)
        {
            entidad.Id = Guid.NewGuid();
            db.Paises.Add(entidad);
            return entidad;
        }

        public Pais Editar(Pais entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Pais entidad)
        {
            db.Paises.Remove(entidad);
        }
        public List<Pais> Listar()
        {
            return db.Paises.ToList();
        }

        public Pais ObtenerPorId(Guid id)
        {
            var pais = db.Paises.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Usuario no encontrado");
            return pais;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public Pais ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoRepositoryUsuarioTipo
        : IRepositoryBase<UsuarioTipo, int, Guid>
    {
        private DBContext db;

        public CatalogoRepositoryUsuarioTipo(DBContext _db)
        {
            db = _db;
        }

        public UsuarioTipo Agregar(UsuarioTipo entidad)
        {
            db.UsuarioTipos.Add(entidad);
            return entidad;
        }

        public UsuarioTipo Editar(UsuarioTipo entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(UsuarioTipo entidad)
        {
            db.UsuarioTipos.Remove(entidad);
        }
        public List<UsuarioTipo> Listar()
        {
            return db.UsuarioTipos.ToList();
        }

        public UsuarioTipo ObtenerPorId(int id)
        {
            var usuarioTipo = db.UsuarioTipos.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Usuario no encontrado");
            return usuarioTipo;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public UsuarioTipo ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }   

    public class CatalogoRepositoryIngredienteCategoria
        : IRepositoryBase<IngredienteCategoria, int, Guid>
    {
           private DBContext db;

        public CatalogoRepositoryIngredienteCategoria(DBContext _db)
        {
            db = _db;
        }

        public IngredienteCategoria Agregar(IngredienteCategoria entidad)
        {
            entidad.Id = Guid.NewGuid();
            db.IngredienteCategorias.Add(entidad);
            return entidad;
        }

        public IngredienteCategoria Editar(IngredienteCategoria entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(IngredienteCategoria entidad)
        {
            db.IngredienteCategorias.Remove(entidad);
        }
        public List<IngredienteCategoria> Listar()
        {
            return db.IngredienteCategorias.ToList();
        }

        public IngredienteCategoria ObtenerPorId(Guid id)
        {
            var ingredienteCategoria = db.IngredienteCategorias.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Receta no encontrado");
            return ingredienteCategoria;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public IngredienteCategoria ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoRepositoryRecetaCategoria
        : IRepositoryBase<RecetaCategoria, int, Guid>
    {
           private DBContext db;

        public CatalogoRepositoryRecetaCategoria(DBContext _db)
        {
            db = _db;
        }

        public RecetaCategoria Agregar(RecetaCategoria entidad)
        {
            entidad.Id = Guid.NewGuid();
            db.RecetaCategorias.Add(entidad);
            return entidad;
        }

        public RecetaCategoria Editar(RecetaCategoria entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(RecetaCategoria entidad)
        {
            db.RecetaCategorias.Remove(entidad);
        }
        public List<RecetaCategoria> Listar()
        {
            return db.RecetaCategorias.ToList();
        }

        public RecetaCategoria ObtenerPorId(Guid id)
        {
            var recetaCategoria = db.RecetaCategorias.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Receta no encontrado");
            return recetaCategoria;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public RecetaCategoria ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoRepositoryRecetaDificultad
        : IRepositoryBase<RecetaDificultad, int, Guid>
    {
           private DBContext db;

        public CatalogoRepositoryRecetaDificultad(DBContext _db)
        {
            db = _db;
        }

        public RecetaDificultad Agregar(RecetaDificultad entidad)
        {
            db.RecetaDificultades.Add(entidad);
            return entidad;
        }

        public RecetaDificultad Editar(RecetaDificultad entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(RecetaDificultad entidad)
        {
            db.RecetaDificultades.Remove(entidad);
        }
        public List<RecetaDificultad> Listar()
        {
            return db.RecetaDificultades.ToList();
        }

        public RecetaDificultad ObtenerPorId(int id)
        {
            var recetaDificultad = db.RecetaDificultades.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Receta no encontrado");
            return recetaDificultad;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public RecetaDificultad ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoRepositoryUnidadMedida
        : IRepositoryBase<UnidadMedida, int, Guid>
    {
           private DBContext db;

        public CatalogoRepositoryUnidadMedida(DBContext _db)
        {
            db = _db;
        }

        public UnidadMedida Agregar(UnidadMedida entidad)
        {
            db.UnidadMedidas.Add(entidad);
            return entidad;
        }

        public UnidadMedida Editar(UnidadMedida entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(UnidadMedida entidad)
        {
            db.UnidadMedidas.Remove(entidad);
        }
        public List<UnidadMedida> Listar()
        {
            return db.UnidadMedidas.ToList();
        }

        public UnidadMedida ObtenerPorId(int id)
        {
            var unidadMedida = db.UnidadMedidas.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Receta no encontrado");
            return unidadMedida;
        }
        public void Guardar()
        {
            db.SaveChanges();
        }

        public UnidadMedida ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoRepositoryEventoTipo
        : IRepositoryBase<EventoTipo, int, Guid>
    {
           private DBContext db;

        public CatalogoRepositoryEventoTipo(DBContext _db)
        {
            db = _db;
        }

        public EventoTipo Agregar(EventoTipo entidad)
        {
            db.EventoTipos.Add(entidad);
            return entidad;
        }

        public EventoTipo Editar(EventoTipo entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(EventoTipo entidad)
        {
            db.EventoTipos.Remove(entidad);
        }
        public List<EventoTipo> Listar()
        {
            return db.EventoTipos.ToList();
        }

        public EventoTipo ObtenerPorId(int id)
        {
            var eventoTipo = db.EventoTipos.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Receta no encontrado");
            return eventoTipo;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public EventoTipo ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
