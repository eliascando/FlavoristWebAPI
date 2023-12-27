using Application.Interfaces;
using Domain;
using Domain.Interfaces.Repository;
using System.Diagnostics;

namespace Application.Services
{
    public class PostService
        : IServicePost<Receta, Guid>
    {
        private IRepositoryPost<Receta, Guid> _repository;
        private IRepositoryBase<RecetaPaso, Guid> _repositoryRecetaPaso;
        private IRepositoryBase<RecetaIngrediente, Guid> _repositoryRecetaIngrediente;

        public PostService(
            IRepositoryPost<Receta, Guid> repository,
            IRepositoryBase<RecetaPaso, Guid> repositoryRecetaPaso,
            IRepositoryBase<RecetaIngrediente, Guid> repositoryRecetaIngrediente
        )
        {
            _repository = repository;
            _repositoryRecetaPaso = repositoryRecetaPaso;
            _repositoryRecetaIngrediente = repositoryRecetaIngrediente;
        }

        public Receta Agregar(Receta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("Receta", "No se puede agregar una receta nula");
            Debug.WriteLine(entidad.Id);

            entidad.Id = Guid.NewGuid();

            entidad.RecetaPasos.ForEach( paso =>{
                if(paso == null)
                    throw new ArgumentNullException("RecetaPaso", "No se puede agregar un paso nulo");

                paso.Id = Guid.NewGuid();
                paso.RecetaID = entidad.Id;
                paso.Orden = entidad.RecetaPasos.IndexOf(paso)+1;
            });

            entidad.RecetaIngredientes.ForEach( ingrediente =>
            {
                if(ingrediente == null)
                    throw new ArgumentNullException("RecetaIngrediente", "No se puede agregar un ingrediente nulo");

                ingrediente.Id = Guid.NewGuid();
                ingrediente.RecetaID = entidad.Id;
            });

            var resultado = _repository.Agregar(entidad);
            _repository.Guardar();
            return resultado;
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public List<Receta> ListarPorCategoria(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Receta> ListarPorIngrediente(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Receta> ListarPorUsuario(Guid id)
        {
            throw new NotImplementedException();
        }

        public Receta ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Receta Editar(Receta entidad)
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
