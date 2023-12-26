using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IListar<T, TId>
    {
        List<T> Listar();
        T ObtenerPorId(TId id);
    }
}
