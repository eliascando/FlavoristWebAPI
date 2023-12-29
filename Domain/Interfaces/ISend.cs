namespace Domain.Interfaces
{
    public interface ISend<To, Msg, Sub>
    {
        Task<Boolean> Send(To to, Msg msg, Sub sub);
    }
}
