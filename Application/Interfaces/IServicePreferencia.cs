using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IServicePreferencia<T, Uid>
        : IPreferencia<T, Uid>, IEliminar<T>, IAgregar<T>
    {

    }
}
