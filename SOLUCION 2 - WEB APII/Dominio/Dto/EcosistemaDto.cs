using Dominio.Entidades;
using Dominio.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class EcosistemaDto : IValidable
    {
        public string EcNombre { get; set; }
        public int EcUbicacionGeograficaId { get; set; } // Clave externa
        public UbicacionGeografica EcUbicacionGeografica { get; set; }
        public int EcArea { get; set; }
        public string EcCaracteristicas { get; set; }
        public EstadoDeConservacion EcEstadoDeConservacion { get; set; }

        public string EstadoDeConservacionId { get; set; }

        public IEnumerable<EcosistemaAmenaza> EcosistemaAmenaza { get; set; }

        public List<int> AmenazasIds { get; set; }
        public Pais Pais { get; set; }

        public string PaisId { get; set; }
        public List<string> EspecieIds { get; set; }
        public IEnumerable<EcosistemaEspecie> EcosistemaEspecie { get; set; }

        // public ICollection<EcosistemaPais> EcosistemaPais { get; set; } = new List<EcosistemaPais>();

        public EcosistemaDto() { }

        public EcosistemaDto(Ecosistema ecosistema)
        {
            this.EcNombre = ecosistema.EcNombre;
            this.EcUbicacionGeografica = ecosistema.EcUbicacionGeografica;
            this.EcUbicacionGeograficaId = ecosistema.EcUbicacionGeograficaId;
            this.EcArea = ecosistema.EcArea;
            this.EcCaracteristicas = ecosistema.EcCaracteristicas;
            this.EspecieIds = ecosistema.EspecieIds;
            this.Pais = ecosistema.Pais;
            this.AmenazasIds = ecosistema.AmenazasIds;
            this.PaisId = ecosistema.PaisId;
            this.EstadoDeConservacionId = ecosistema.EstadoDeConservacionId;
        }

        public void Validar(){}
    }
}
