using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class UbicacionGeograficaDto
    {
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }

        public int UbicacionGeograficaId { get; set; }
        public Ecosistema Ecosistema { get; set; }

        public UbicacionGeograficaDto() { }
        public UbicacionGeograficaDto(UbicacionGeografica ubicacionGeografica)
        {
            Latitud = ubicacionGeografica.Latitud;
            Longitud = ubicacionGeografica.Longitud;
            UbicacionGeograficaId = ubicacionGeografica.UbicacionGeograficaId;
        }

        public UbicacionGeograficaDto(decimal latitud, decimal longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }
    }
}
