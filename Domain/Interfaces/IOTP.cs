namespace Domain.Interfaces
{
    public interface IOTP<TId>
    {
        string GenerarOTP(TId id);
        bool ValidarOTP(TId id, string otp);
    }
}
