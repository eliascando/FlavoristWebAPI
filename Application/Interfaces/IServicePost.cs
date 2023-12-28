using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IServicePost <T, TId>
        : IAgregar<T>, IEditar<T>, IListarReceta<T, TId>, IEliminar<TId>, ITransaccion
    {

    }
}
