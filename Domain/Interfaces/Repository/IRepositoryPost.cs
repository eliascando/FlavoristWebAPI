namespace Domain.Interfaces.Repository
{
    public interface IRepositoryPost <T, TId>
        : IAgregar<T>, IEditar<T>, IListarReceta<T, TId>, IEliminar<TId>, ITransaccion
    {

    }
}
