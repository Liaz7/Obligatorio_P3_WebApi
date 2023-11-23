using Dominio.Dto;
using Dominio.Entidades;
using Dominio.Entidades.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Ecosistema : IValidable
    {
        public string EcNombre { get; set; }

        public int EcUbicacionGeograficaId { get; set; } // Clave externa
        public UbicacionGeografica EcUbicacionGeografica { get; set; }
        public int EcArea { get; set; }
        public string EcCaracteristicas { get; set; }
        public EstadoDeConservacion EstadoDeConservacion { get; set; }
        public List<int> AmenazasIds { get; set; }
        public string EstadoDeConservacionId { get; set; }
        public IEnumerable<EcosistemaAmenaza> EcosistemaAmenaza { get; set; }
        public Pais Pais { get; set; }

        public string PaisId { get; set; }
        public List<string> EspecieIds { get; set; }
        public IEnumerable<EcosistemaEspecie> EcosistemaEspecie { get; set; }

        // public ICollection<EcosistemaPais> EcosistemaPais { get; set; } = new List<EcosistemaPais>();

        public Ecosistema() { }

        public Ecosistema(EcosistemaDto ecosistemaDto)
        {
            this.EcNombre = ecosistemaDto.EcNombre;          
            this.EcUbicacionGeografica = ecosistemaDto.EcUbicacionGeografica;
            this.EcUbicacionGeograficaId = ecosistemaDto.EcUbicacionGeograficaId;
            this.EcArea = ecosistemaDto.EcArea;
            this.EcCaracteristicas = ecosistemaDto.EcCaracteristicas;
            this.EspecieIds = ecosistemaDto.EspecieIds;
            this.Pais = ecosistemaDto.Pais;
            this.AmenazasIds = ecosistemaDto.AmenazasIds;
            this.PaisId = ecosistemaDto.PaisId;
            this.EstadoDeConservacionId = ecosistemaDto.EstadoDeConservacionId;
        }

        public void CopyEcosistema(EcosistemaDto ecosistemaDto)
        {
            this.EcNombre = ecosistemaDto.EcNombre;
            this.EcUbicacionGeografica = ecosistemaDto.EcUbicacionGeografica;
            this.EcUbicacionGeograficaId = ecosistemaDto.EcUbicacionGeograficaId;
            this.EcArea = ecosistemaDto.EcArea;
            this.EcCaracteristicas = ecosistemaDto.EcCaracteristicas;
            this.EspecieIds = ecosistemaDto.EspecieIds;
            this.Pais = ecosistemaDto.Pais;
            this.AmenazasIds = ecosistemaDto.AmenazasIds;
            this.PaisId = ecosistemaDto.PaisId;
            this.EstadoDeConservacionId = ecosistemaDto.EstadoDeConservacionId;
        }

        public virtual void Validar()
        {
            ValidarNombre();
            ValidarArea();
            ValidarAmenazas();
            ValidarEspecies();
            ValidarUbicacionGeografica();
        }

        public void ValidarNombre()
        {
            if (EcNombre.IsNullOrEmpty()) throw new Exception("El nombre no puede estar vacio");
        }

        public void ValidarArea()
        {
            if (EcArea < 0) throw new Exception("El area debe ser positiva y en m2");
        }

        public void ValidarAmenazas()
        {
            if (AmenazasIds.Count() == 0) throw new Exception("Debe seleccionar al menos una Amenaza");
        }

        public void ValidarEspecies()
        {
            if (EspecieIds.Count() == 0) throw new Exception("Debe seleccionar al menos una Especie");
        }

        public void ValidarUbicacionGeografica()
        {
            if (EcUbicacionGeografica.Latitud == 0 || EcUbicacionGeografica.Longitud == 0) throw new Exception("Es necesario ingrear una Ubicacion Geografica.");
        }
    }
}
