﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Exceptions
{
    public class ElementoEnConflictoException : Exception
    {
        public ElementoEnConflictoException(string message) : base(message) { }
    }
}
