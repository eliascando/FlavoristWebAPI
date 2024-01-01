namespace Domain.Interfaces.Repository
{
    public interface IRepositoryBase <T, IntId, GuidId>
        : IAgregar<T>, IEditar<T>, IEliminar<T>, IListar<T, IntId, GuidId>, ITransaccion
    {

    }
}
