using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class EcosistemaAmenaza
    {
        public int AmId { get; set; }
        public string EcNombre { get; set; }

        public Amenaza Amenaza { get; set; }

        public Ecosistema Ecosistema { get; set; }

        public EcosistemaAmenaza()
        {
        }

        public EcosistemaAmenaza(int amenaza, string eco)
        {
            this.EcNombre = eco;
            this.AmId = amenaza;
        }
    }
}
