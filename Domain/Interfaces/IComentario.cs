namespace Domain.Interfaces
{
    public interface IComentario<T, TId>
    {
        void EliminarComentario(TId id);
        List<T> ObtenerComentariosPadres(TId id);
        List<T> ObtenerComentariosHijos(TId id);
    }
}
