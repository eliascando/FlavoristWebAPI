namespace Domain.Interfaces
{
    public interface IOTP<TId>
    {
        string GenerarOTP(TId id, int delta);
        bool ValidarOTP(TId id, string otp);
    }
}
