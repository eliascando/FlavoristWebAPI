namespace Domain.Interfaces
{
    public interface IFollow <T, TId, TFl, TFw>
    {
        List<T> ObtenerSeguidores(TId id);
        List<T> ObtenerSeguidos(TId id);
        bool EliminarPorSeguidorYSeguido(TFl seguidor, TFw seguido);
    }
}
