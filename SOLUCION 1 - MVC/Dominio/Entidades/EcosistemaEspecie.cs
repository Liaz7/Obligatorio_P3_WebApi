using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class EcosistemaEspecie
    {
        public string EsNombreCientifico { get; set; }
        public string EcNombre { get; set; }
        public bool Habitan { get; set; }
        public Especie Especie { get; set; }

        public Ecosistema Ecosistema { get; set; }

        public EcosistemaEspecie()
        {
        }

        public EcosistemaEspecie(string especie, string eco, bool habitan)
        {
            this.EcNombre = eco;
            this.EsNombreCientifico = especie;
            this.Habitan = habitan;
        }
    }
}
