using Domain.Entities;
using Domain.Interfaces.Repository;
using Infraestructure.Persistence.Context;
using System.Diagnostics;

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
            Debug.WriteLine($"Eliminando preferencia de categoria {entidad.RecetaCategoriaID} del usuario {entidad.UsuarioID}");
            var preferencia = db.UsuarioRecetaCategoriaFavs.Where(x => x.UsuarioID == entidad.UsuarioID && x.RecetaCategoriaID == entidad.RecetaCategoriaID).FirstOrDefault() ?? throw new Exception("No se encontró la preferencia");
            db.UsuarioRecetaCategoriaFavs.Remove(preferencia);
            db.SaveChanges();
        }

        public bool ExistePreferencia(Guid uid, Guid id)
        {
            var encontrado = db.UsuarioRecetaCategoriaFavs.Where(x => x.UsuarioID == uid && x.RecetaCategoriaID == id).FirstOrDefault();

            return encontrado != null;
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
            var preferencia = db.UsuarioRecetaFavs.Where(x => x.UsuarioID == entidad.UsuarioID && x.RecetaID == entidad.RecetaID).FirstOrDefault() ?? throw new Exception("No se encontró la preferencia");
            db.UsuarioRecetaFavs.Remove(preferencia);
            db.SaveChanges();
        }

        public bool ExistePreferencia(Guid uid, Guid id)
        {
            var encontrado = db.UsuarioRecetaFavs.Where(x => x.UsuarioID == uid && x.RecetaID == id).FirstOrDefault();
            
            return encontrado != null;
        }

        public List<UsuarioRecetaFav> ObtenerPreferenciasPorUsuario(Guid uid)
        {
            var preferencias = db.UsuarioRecetaFavs.Where(x => x.UsuarioID == uid).ToList();
            return preferencias;
        }
    }
}
