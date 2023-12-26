using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoryPost <T, TId>
        : IAgregar<T>, IEditar<T>, IListar<T, TId>, ITransaccion
    {

    }
}
