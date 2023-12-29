using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface INotificacion<T, Uid>
    {
        Task<List<T>> ObtenerNotificaciones(Uid id); 
    }
}
