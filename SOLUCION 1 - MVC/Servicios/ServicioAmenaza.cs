using DataAccess;
using Dominio.Dto;
using Dominio.Entidades;
using Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Servicios
{
    public class ServicioAmenaza : IServicioAmenaza
    {
        private IRepositorioAmenaza _repositorio;

        public ServicioAmenaza(IRepositorioAmenaza repositorio)
        {
            _repositorio = repositorio;

        }

        private void ThrowExceptionIfNotFound(Especie especie)
        {
            if (especie == null)
            {
                throw new ElementoNoEncontradoException("No se encontro la especie");
            }
        }

        private IEnumerable<AmenazaDto> ConvertirListaAListaDto(IEnumerable<Amenaza> amenazas)
        {
            List<AmenazaDto> amenazasDto = new List<AmenazaDto>();
            foreach (Amenaza a in amenazas)
            {
                AmenazaDto amenazaDto = new AmenazaDto(a);
                amenazasDto.Add(amenazaDto);
            }
            return amenazasDto;
        }

        public IEnumerable<AmenazaDto> GetAll()
        {
            return ConvertirListaAListaDto(_repositorio.GetAll());
        }

        public AmenazaDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        /*public AmenazaDto GetById(int id)
        {
            Amenaza amenaza = _repositorio.GetById(id);
            AmenazaDto amenazaDto = new AmenazaDto(amenaza);
            return amenazaDto;
        }*/
    }
}
