using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthorization<T, TResult>
    {
        string GenerateToken(T user);
        //TResult ValidateToken(string token);
    }
}
