namespace Domain.Interfaces.Repository
{
    public interface IRepositoryPreferencia<T, Uid>
        : IAgregar<T>, IPreferencia<T, Uid>, IEliminar<T>
    {

    }
}
