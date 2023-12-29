using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IServiceLike<T, TDto,U, Tid, UId>
        : ILike<T, TDto,U, Tid, UId>
    {

    }
}
