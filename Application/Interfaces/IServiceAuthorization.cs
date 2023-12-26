using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;
using Domain.DTOs;

namespace Application.Interfaces
{
    public interface IServiceAuthorization<T, TResult>
        : IAuthorization<T, TResult>
    {

    }
}
