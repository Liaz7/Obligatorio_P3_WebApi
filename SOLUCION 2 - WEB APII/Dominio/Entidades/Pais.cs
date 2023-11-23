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
        public string EcNombrePais { get; set; }
        public string EcIsoPais { get; set; }
        public List<string> EcosistemasIdsPais { get; set; }
        public ICollection<Ecosistema> Ecosistemas { get; set; }

        //public ICollection<EcosistemaPais> EcosistemaPais { get; set; } = new List<EcosistemaPais>();

        public Pais(PaisDto pais) 
        {
            this.EcIsoPais = pais.PaisIso;
            this.EcNombrePais = pais.PaisNombre;
        }

        public Pais()
        {
            
        }

    }
}
