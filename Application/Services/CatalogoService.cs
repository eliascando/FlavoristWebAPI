using Application.Interfaces;
using Domain;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CatalogoService
        : IServiceBase<Pais, Guid>
    {
        private readonly IRepositoryBase<Pais, Guid> _reposPais;

        public CatalogoService(IRepositoryBase<Pais, Guid> reposPais)
        {
            _reposPais = reposPais;
        }
        #region PaisCatalogo
        public Pais Agregar(Pais entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("Pais", "No se puede agregar un pais nulo");

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
            throw new NotImplementedException();
        }

        public Pais ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
