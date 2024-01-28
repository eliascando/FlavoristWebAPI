using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IListarReceta<T, TId>
    {
        T ObtenerPorId(TId id);
        List<T> ListarPorUsuario(TId id);
        List<T> ListarPorCategoria(TId id);
        List<T> ListarPorIngrediente(TId id);
        List<T> ListorPorSeguidos(Guid idUsuario);
        List<T> ListarExplorer(Guid idUsuario);
    }
}
