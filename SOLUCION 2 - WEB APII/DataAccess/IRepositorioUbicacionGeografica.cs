using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositorioUbicacionGeografica : IRepositorio<UbicacionGeografica>
    {
        public UbicacionGeografica GetById(int id);

        /*public UbicacionGeografica GetByLatitudYLongitud(decimal latitud, decimal longitud);*/
    }
}
