using Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Amenaza
    {
        public int AmId { get; set; }
        public string AmNombre { get; set; }

        public string AmGradoPeligrosidad { get; set; }
        public IEnumerable<EcosistemaAmenaza> EcosistemaAmenaza { get; set; }
        public IEnumerable<EspecieAmenaza> EspecieAmenaza { get; set; }

        public Amenaza() { }

        public Amenaza(AmenazaDto a) {
            this.AmId = a.AmId;
            this.AmNombre = a.AmNombre;
            this.AmGradoPeligrosidad = a.AmGradoPeligrosidad;
        }
    }
}
