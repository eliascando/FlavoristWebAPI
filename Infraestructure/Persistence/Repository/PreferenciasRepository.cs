using Domain.Entities;
using Domain.Interfaces.Repository;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repository
{
    public class PreferenciaCategoriaRepository
        : IRepositoryPreferencia<UsuarioRecetaCategoriaFav, Guid>
    {
        private DBContext db;

        public PreferenciaCategoriaRepository(DBContext _db)
        {
            db = _db;
        }

        public UsuarioRecetaCategoriaFav Agregar(UsuarioRecetaCategoriaFav entidad)
        {
            db.UsuarioRecetaCategoriaFavs.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public void Eliminar(UsuarioRecetaCategoriaFav entidad)
        {
            db.UsuarioRecetaCategoriaFavs.Remove(entidad);
            db.SaveChanges();
        }

        public List<UsuarioRecetaCategoriaFav> ObtenerPreferenciasPorUsuario(Guid uid)
        {
            var preferencias = db.UsuarioRecetaCategoriaFavs.Where(x => x.UsuarioID == uid).ToList();
            return preferencias;
        }
    }

    public class PreferenciasRecetaRepository
        : IRepositoryPreferencia<UsuarioRecetaFav, Guid>
    {
        private DBContext db;

        public PreferenciasRecetaRepository(DBContext _db)
        {
            db = _db;
        }

        public UsuarioRecetaFav Agregar(UsuarioRecetaFav entidad)
        {
            db.UsuarioRecetaFavs.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public void Eliminar(UsuarioRecetaFav entidad)
        {
            db.UsuarioRecetaFavs.Remove(entidad);
            db.SaveChanges();
        }

        public List<UsuarioRecetaFav> ObtenerPreferenciasPorUsuario(Guid uid)
        {
            var preferencias = db.UsuarioRecetaFavs.Where(x => x.UsuarioID == uid).ToList();
            return preferencias;
        }
    }
}
