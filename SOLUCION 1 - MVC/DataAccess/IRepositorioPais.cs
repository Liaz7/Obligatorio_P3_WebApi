using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositorioPais : IRepositorio<Pais>
    {
        IEnumerable<Pais> GetAll();

        Pais GetByNombre(string nombre);
    }
}
