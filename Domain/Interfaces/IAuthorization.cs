namespace Domain.Interfaces
{
    public interface IAuthorization<T, TResult>
    {
        string GenerateToken(T user);
    }
}
