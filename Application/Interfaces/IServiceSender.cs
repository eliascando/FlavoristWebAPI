using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IServiceSender<To, Msg, Sub>
       : ISend<To, Msg, Sub>
    {

    }
}
