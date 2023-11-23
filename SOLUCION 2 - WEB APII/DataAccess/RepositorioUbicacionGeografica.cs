using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioUbicacionGeografica : Repositorio<UbicacionGeografica>, IRepositorioUbicacionGeografica 
    {
        public RepositorioUbicacionGeografica(DbContext dbContext)
        {
            Context = dbContext;
        }
        public UbicacionGeografica GetById(int id)
        {
            return Context.Set<UbicacionGeografica>().FirstOrDefault(eo => eo.UbicacionGeograficaId == id);
        }

        public UbicacionGeografica GetByLatitudYLongitud(decimal latitud, decimal longitud)
        {
            return Context.Set<UbicacionGeografica>()
                .FirstOrDefault(eo => eo.Latitud == latitud && eo.Longitud == longitud);
        }
    }
}
