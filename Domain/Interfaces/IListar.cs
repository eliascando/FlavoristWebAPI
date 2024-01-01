namespace Domain.Interfaces
{
    public interface IListar<T, IntId, GuidId>
    {
        List<T> Listar();
        T ObtenerPorId(IntId id);
        T ObtenerPorId(GuidId id);
    }
}
