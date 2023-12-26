namespace Domain.Interfaces
{
    public interface IListar<T, TId>
    {
        List<T> Listar();
        T ObtenerPorId(TId id);
    }
}
