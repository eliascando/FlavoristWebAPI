namespace Domain.Interfaces
{
    public interface IAgregarComentario<T, TDto>
    {
        T AgregarComentario(TDto entity);
    }
}
