using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositorioEstadoDeConservacion : IRepositorio<EstadoDeConservacion>
    {
        IEnumerable<EstadoDeConservacion> GetAll();

        EstadoDeConservacion GetByNombre(string nombre);
    }
}
