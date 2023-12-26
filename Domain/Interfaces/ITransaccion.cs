using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITransaccion
    {
        void Begin();
        void Commit();
        void Rollback();
        void Guardar();
    }
}
