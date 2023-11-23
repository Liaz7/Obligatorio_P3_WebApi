using Dominio.Entidades;
using Dominio.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class EstadoDeConservacionDto : IValidable
    {
        public string ConsId { get; set; }
        public string ConsNombre { get; set; }
        public int ConsValoresNumericos { get; set; }
        public IEnumerable<Ecosistema> Ecosistema { get; set; }
        public IEnumerable<Especie> Especie { get; set; }

        public EstadoDeConservacionDto() { 
        }

        public EstadoDeConservacionDto(EstadoDeConservacion estadoDeConservacion)
        {
            this.ConsId = estadoDeConservacion.ConsId;
            this.ConsNombre = estadoDeConservacion.ConsNombre;
            this.ConsValoresNumericos = estadoDeConservacion.ConsValoresNumericos;
        }

        public void Validar(){}
    }
}
