﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Exceptions
{
    public class ElementoNoEncontradoException : Exception
    {
        public ElementoNoEncontradoException(string message) : base(message) { }
    }
}
