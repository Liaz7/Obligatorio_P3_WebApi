using Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IServicioAmenaza
    {
        IEnumerable<AmenazaDto> GetAll();

        //AmenazaDto GetById(int id);
    }
}
