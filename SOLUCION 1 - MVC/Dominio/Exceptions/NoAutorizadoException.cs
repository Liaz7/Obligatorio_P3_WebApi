﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Exceptions
{
    public class NoAutorizadoException : Exception
    {
        public NoAutorizadoException(string message) : base(message) { }
    }
}
