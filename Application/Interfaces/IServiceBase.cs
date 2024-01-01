using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IServiceBase<T, IntId, GuidId>
        : IAgregar<T>, IListar<T, IntId, GuidId>, IEditar<T>, IEliminar<T>
    {

    }
}
