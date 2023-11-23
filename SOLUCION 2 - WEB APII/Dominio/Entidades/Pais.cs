using Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Pais
    {
        public string PaisIso { get; set; }
        public string PaisNombre { get; set; }
        public List<string> EcosistemasIdsPais { get; set; }
        public ICollection<Ecosistema> Ecosistemas { get; set; }

        //public ICollection<EcosistemaPais> EcosistemaPais { get; set; } = new List<EcosistemaPais>();

        public Pais(PaisDto pais) 
        {
            this.PaisIso = pais.PaisIso;
            this.PaisNombre = pais.PaisNombre;
        }

        public Pais()
        {
            
        }

    }
}
