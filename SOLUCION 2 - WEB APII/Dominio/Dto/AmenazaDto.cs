using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class AmenazaDto
    {
        public int AmId { get; set; }
        public string AmNombre { get; set; }

        public string AmGradoPeligrosidad { get; set; }
        public IEnumerable<EcosistemaAmenaza> EcosistemaAmenaza { get; set; }

        public IEnumerable<EspecieAmenaza> EspecieAmenaza { get; set; }

        public AmenazaDto() { }
        public AmenazaDto(Amenaza amenaza) {
            this.AmId = amenaza.AmId;
            this.AmNombre = amenaza.AmNombre;
            this.AmGradoPeligrosidad = amenaza.AmGradoPeligrosidad;
        }
    }
}
