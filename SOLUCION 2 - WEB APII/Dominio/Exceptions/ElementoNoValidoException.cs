using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Exceptions
{
    public class ElementoNoValidoException : Exception
    {
        public ElementoNoValidoException(string message) : base(message) { }
    }
}
