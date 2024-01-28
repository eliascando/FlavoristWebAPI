namespace Domain.Interfaces
{
    public interface ILike<T, TDto,U, TId, UId>
    {
        T DarLikeDesdeDTO (TDto entidadDTO);
        T DarLike(T entidad);
        int ObtenerCantidadLikeDePost(TId referenciaId);
        List<U> ObtenerLikesOwners(TId referenciaId);
        bool EliminarLikePorUsuarioYPost(UId usuario, TId referenciaId);
        bool ExisteLikeDeUsuarioEnPost(UId usuario, TId referenciaId);
    }
}
