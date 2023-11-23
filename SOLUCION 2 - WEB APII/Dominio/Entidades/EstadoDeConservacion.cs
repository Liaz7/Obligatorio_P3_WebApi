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
    public class EstadoDeConservacion : IValidable
    {
        public string ConsId { get; set; }
        public string ConsNombre { get; set; }
        public int ConsValoresNumericos { get; set; }
        public IEnumerable<Ecosistema> Ecosistema { get; set; }
        public IEnumerable<Especie> Especie { get; set; }
        public EstadoDeConservacion() { }

        public EstadoDeConservacion(EstadoDeConservacionDto estadoDeConservacionDto)
        {
            this.ConsId = estadoDeConservacionDto.ConsId;
            this.ConsNombre = estadoDeConservacionDto.ConsNombre;
            this.ConsValoresNumericos = estadoDeConservacionDto.ConsValoresNumericos;
        }

        public virtual void Validar()
        {
            ValidarNombre();
            ValidarValoresNumericos();
        }

        public void ValidarNombre()
        {
            if (ConsNombre.IsNullOrEmpty()) throw new Exception("El nombre del estado no puede ser nulo");
        }

        public void ValidarValoresNumericos()
        {
            if (ConsValoresNumericos < 0 || ConsValoresNumericos > 100) throw new Exception("Solo se permiten valores entre (0-100)");
        }
    }
}
