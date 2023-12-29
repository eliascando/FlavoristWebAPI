namespace Domain.Interfaces.Repository
{
    public interface IRepositoryComentario<T, TId>
        : IComentario<T, TId>, IAgregar<T>, ITransaccion
    {

    }
}
