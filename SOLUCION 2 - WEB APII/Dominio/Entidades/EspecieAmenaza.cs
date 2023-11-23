using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class EspecieAmenaza
    {
        public int AmId { get; set; }
        public string EcNombre { get; set; }

        public Especie Especie { get; set; }

        public Amenaza Amenaza { get; set; }

        public EspecieAmenaza()
        {
        }

        public EspecieAmenaza(int amid, string eco)
        {
            this.EcNombre = eco;
            this.AmId = amid;
        }

    }
}
