using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IServiceBase<T, TID>
        : IAgregar<T>, IListar<T, TID>, IEditar<T>, IEliminar<T>
    {

    }
}
