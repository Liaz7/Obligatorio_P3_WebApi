using DataAccess;
using Dominio.Dto;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioUbicacionGeografica : IServicioUbicacionGeografica
    {
        private IRepositorioUbicacionGeografica _repositorio;
       

        public ServicioUbicacionGeografica(IRepositorioUbicacionGeografica repositorio)
        {
            _repositorio = repositorio;
        }

        public UbicacionGeograficaDto GetById(int id)
        {
            UbicacionGeografica ubicacionGeografica = _repositorio.GetById(id);
           // ThrowExceptionIfNotFound(ubicacionGeografica);
            UbicacionGeograficaDto ubicacionGeograficaDto = new UbicacionGeograficaDto(ubicacionGeografica);
            return ubicacionGeograficaDto;
        }
    }
}
