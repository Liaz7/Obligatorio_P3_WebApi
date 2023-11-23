using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioEstadoDeConservacion : Repositorio<EstadoDeConservacion>, IRepositorioEstadoDeConservacion
    {
        public RepositorioEstadoDeConservacion(DbContext dbContext)
        {
            Context = dbContext;
        }
        public IEnumerable<EstadoDeConservacion> GetAll()
        {
            return Context.Set<EstadoDeConservacion>().ToList();
        }

        public EstadoDeConservacion GetByNombre(string nombre)
        {
            return Context.Set<EstadoDeConservacion>().FirstOrDefault(estado => estado.ConsId == nombre);
        }
    }
}
