using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class PaisDto
    {
        public string PaisIso { get; set; }
        public string PaisNombre { get; set; }

        public List<string> EcosistemasIdsPais { get; set; }
        public ICollection<Ecosistema> Ecosistemas { get; set; }

        public PaisDto() { }

        public PaisDto(Pais pais)
        {
            this.PaisIso = pais.PaisIso;
            this.PaisNombre = pais.PaisNombre;
            this.EcosistemasIdsPais = pais.EcosistemasIdsPais;
        }
    }
}
