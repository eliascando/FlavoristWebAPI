namespace Domain.Interfaces
{
    public interface ILogin<T, TResult>
    {
        TResult Login(T entity);
    }
}
