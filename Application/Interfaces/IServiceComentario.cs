using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IServiceComentario<T, TDto ,TId>
        : IComentario<T, TId>, IAgregarComentario<T, TDto>
    {
    }
}
