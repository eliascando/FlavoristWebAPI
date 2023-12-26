using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IServiceBase<T, TID>
        : IAgregar<T>, IListar<T, TID>, IEditar<T>, IEliminar<T>
    {

    }
}
