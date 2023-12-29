using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPassword<TId, TP>
    {
        bool CambiarPassword(TId id, TP pass);
        string ObtenerCorreo(TId id);
    }
}
