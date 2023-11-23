using Dominio.Entidades;
using Dominio.Entidades.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class EspecieDto : IValidable
    {
        public string EsNombreCientifico { get; set; }
        public string EsNombreVulgar { get; set; }
        public string EsDescripcion { get; set; }
        public decimal EsPesoMinimo { get; set; }
        public decimal EsPesoMaximo { get; set; }
        public decimal EsLongitudMinima { get; set; }
        public decimal EsLongitudMaxima { get; set; }
        public string Foto { get; set; }
        public EstadoDeConservacion EsEstadoDeConservacion { get; set; }
        public string EsConsId { get; set; }
        public string EstadoDeConservacionId { get; set; }
        public List<string> EcosistemasIdsTe { get; set; }
        public IEnumerable<EspecieAmenaza> EspecieAmenaza { get; set; }
        public List<int> AmenazasIds { get; set; }
        public IEnumerable<EcosistemaEspecie> EcosistemaEspecie { get; set; }
        public EspecieDto() { }
        public EspecieDto(Especie especie)
        {
            this.EsNombreCientifico = especie.EsNombreCientifico;
            this.EsNombreVulgar = especie.EsNombreVulgar;
            this.EsDescripcion = especie.EsDescripcion;
            this.EsPesoMinimo = especie.EsPesoMinimo;
            this.EsPesoMaximo = especie.EsPesoMaximo;
            this.EsLongitudMinima = especie.EsLongitudMinima;
            this.EsLongitudMaxima = especie.EsLongitudMaxima;
            this.EstadoDeConservacionId = especie.EstadoDeConservacionId;
            this.EcosistemasIdsTe = especie.EcosistemasIdsTe;
            this.AmenazasIds = especie.AmenazasIds;
            this.Foto = especie.Foto;
        }

        public void Validar(){}
    }
}
