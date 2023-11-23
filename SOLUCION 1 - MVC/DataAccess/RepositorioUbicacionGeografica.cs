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
        private IRestContext<UbicacionGeografica> _restContext;

        public RepositorioUbicacionGeografica(IRestContext<UbicacionGeografica> restContext)
        {
            _restContext = restContext;
        }
        public UbicacionGeografica GetById(int id)
        {
            return _restContext.GetById(id).GetAwaiter().GetResult();
        }

        /*public UbicacionGeografica GetByLatitudYLongitud(decimal latitud, decimal longitud)
        {
            return Context.Set<UbicacionGeografica>()
                .FirstOrDefault(eo => eo.Latitud == latitud && eo.Longitud == longitud);
        }*/
    }
}
