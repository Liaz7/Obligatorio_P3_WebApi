using Dominio.Dto;
using Dominio.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class UbicacionGeografica : IValidable
    {
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public int UbicacionGeograficaId { get; set; }

        public UbicacionGeografica() {
          
        }
        public UbicacionGeografica(UbicacionGeograficaDto ubicacionGeograficaDto)
        {
            Latitud = ubicacionGeograficaDto.Latitud;
            Longitud = ubicacionGeograficaDto.Longitud;
            UbicacionGeograficaId = UbicacionGeograficaId;
        }

        public void Validar()
        {
            ValidarLongitudes();
        }

        public void ValidarLongitudes()
        {
            if (Latitud == null || Longitud == null) throw new Exception("Latitud y Longitud no pueden ser nulo");
        }
    }
}
