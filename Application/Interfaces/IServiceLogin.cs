﻿using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceLogin<T, TResult>
        : ILogin<T, TResult>
    {

    }
}
