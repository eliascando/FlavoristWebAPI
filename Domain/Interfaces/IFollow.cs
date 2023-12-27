namespace Domain.Interfaces
{
    public interface IFollow <T, TId>
    {
        List<T> ObtenerSeguidores(TId id);
        List<T> ObtenerSeguidos(TId id);
    }
}
