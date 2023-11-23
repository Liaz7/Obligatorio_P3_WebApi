using Dominio.Dto;
using Dominio.Entidades.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Especie : IValidable
    {
        public string EsNombreCientifico { get; set; }
        public string EsNombreVulgar { get; set; }
        public string EsDescripcion { get; set; }
        public decimal EsPesoMinimo { get; set; }
        public decimal EsPesoMaximo { get; set; }
        public decimal EsLongitudMinima { get; set; }
        public decimal EsLongitudMaxima { get; set; }
        public string Foto { get; set; }
        public EstadoDeConservacion EstadoDeConservacion { get; set; }
        public string EstadoDeConservacionId { get; set; }
        public IEnumerable<EspecieAmenaza> EspecieAmenaza { get; set; }
        public List<int> AmenazasIds { get; set; }
        public IEnumerable<EcosistemaEspecie> EcosistemaEspecie { get; set; }
        public List<string> EcosistemasIdsTe { get; set; }
        public Especie() { }
        public Especie(EspecieDto especieDto)
        {
            this.EsNombreCientifico = especieDto.EsNombreCientifico;
            this.EsNombreVulgar = especieDto.EsNombreVulgar;
            this.EsDescripcion = especieDto.EsDescripcion;
            this.EsPesoMinimo = especieDto.EsPesoMinimo;
            this.EsPesoMaximo = especieDto.EsPesoMaximo;
            this.EsLongitudMinima = especieDto.EsLongitudMinima;
            this.EsLongitudMaxima = especieDto.EsLongitudMaxima;
            this.EstadoDeConservacionId = especieDto.EstadoDeConservacionId;
            this.AmenazasIds = especieDto.AmenazasIds;
            this.EcosistemasIdsTe = especieDto.EcosistemasIdsTe;
            this.Foto = especieDto.Foto;
        }

        public void CopyEspecie(EspecieDto especieDto)
        {
            this.EsNombreCientifico = especieDto.EsNombreCientifico;
            this.EsNombreVulgar = especieDto.EsNombreVulgar;
            this.EsDescripcion = especieDto.EsDescripcion;
            this.EsPesoMinimo = especieDto.EsPesoMinimo;
            this.EsPesoMaximo = especieDto.EsPesoMaximo;
            this.EsLongitudMinima = especieDto.EsLongitudMinima;
            this.EsLongitudMaxima = especieDto.EsLongitudMaxima;
            this.EcosistemasIdsTe = especieDto.EcosistemasIdsTe;
            this.EstadoDeConservacionId = especieDto.EstadoDeConservacionId;
            this.AmenazasIds = especieDto.AmenazasIds;
            this.Foto = especieDto.Foto;
        }

      

        public virtual void Validar()
        {
            ValidarNombreYDescripcion();
            ValidarMagnitudes();
            ValidarAmenazas();
            ValidarEcosistemas();
        }
        public void ValidarNombreYDescripcion()
        {
            if (EsNombreCientifico.IsNullOrEmpty())
            {
                throw new Exception("Debe ingresar un nombre cientifico");
            }
            else if (EsNombreVulgar.IsNullOrEmpty())
            {
                throw new Exception("Debe ingresar un nombre vulgar");
            }
            else if (EsDescripcion.IsNullOrEmpty())
            {
                throw new Exception("Debe ingresar un descripcion para esta especie");
            }
        }

        public void ValidarMagnitudes()
        {
            if (EsPesoMinimo <= 0 || EsPesoMaximo <= 0 || EsLongitudMinima <= 0 || EsLongitudMaxima <= 0)
            {
                throw new Exception("Las magnitudes deben ser positivas");
            }
        }

        public void ValidarAmenazas()
        {
            if (AmenazasIds.Count() == 0) throw new Exception("Debe seleccionar al menos una Amenaza");
        }

        public void ValidarEcosistemas()
        {
            if (EcosistemasIdsTe.Count() == 0) throw new Exception("Debe seleccionar al menos un Ecosistema");
        }

    }
}
