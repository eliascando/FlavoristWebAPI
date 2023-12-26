using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServicePost <T, TId>
        : IAgregar<T>, IEditar<T>, IListar<T, TId>, ITransaccion
    {

    }
}
