namespace Domain.Interfaces.Repository
{
    public interface IRepositoryPost <T, TId>
        : IAgregar<T>, IEditar<T>, IListar<T, TId>, ITransaccion
    {

    }
}
