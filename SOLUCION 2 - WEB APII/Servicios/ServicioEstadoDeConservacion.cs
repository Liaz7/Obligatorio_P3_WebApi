using DataAccess;
using Dominio.Dto;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioEstadoDeConservacion : IServicioEstadoDeConservacion
    {
        private IRepositorioEstadoDeConservacion _repositorio;

        public ServicioEstadoDeConservacion(IRepositorioEstadoDeConservacion repositorio)
        {
            _repositorio = repositorio;

        }
        private IEnumerable<EstadoDeConservacionDto> ConvertirListaAListaDto(IEnumerable<EstadoDeConservacion> estados)
        {
            List<EstadoDeConservacionDto> estadosDto = new List<EstadoDeConservacionDto>();
            foreach (EstadoDeConservacion estado in estados)
            {
                EstadoDeConservacionDto estadoDto = new EstadoDeConservacionDto(estado);
                estadosDto.Add(estadoDto);
            }
            return estadosDto;
        }

        public EstadoDeConservacionDto GetByNombre(string nombre)
        {
            EstadoDeConservacion estado = _repositorio.GetByNombre(nombre);
            EstadoDeConservacionDto estadoDto = new EstadoDeConservacionDto(estado);
            return estadoDto;
        }
        public IEnumerable<EstadoDeConservacionDto> GetAll()
        {
            return ConvertirListaAListaDto(_repositorio.GetAll());
        }
    }
}
