namespace Domain.Interfaces.Repository
{
    public interface IRepositoryBase <T, TId>
        : IAgregar<T>, IEditar<T>, IEliminar<T>, IListar<T, TId>, ITransaccion
    {

    }
}
