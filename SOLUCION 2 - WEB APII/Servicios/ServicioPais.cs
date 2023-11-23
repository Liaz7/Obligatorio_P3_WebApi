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
    public class ServicioPais : IServicioPais
    {
        private IRepositorioPais _repositorio;

        public ServicioPais(IRepositorioPais repositorio)
        {
            _repositorio = repositorio;

        }
        public PaisDto Add(PaisDto paisDto)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<PaisDto> ConvertirListaAListaDto(IEnumerable<Pais> paises)
        {
            List<PaisDto> paisesDto = new List<PaisDto>();
            foreach (Pais pa in paises)
            {
                PaisDto paisDto = new PaisDto(pa);
                paisesDto.Add(paisDto);
            }
            return paisesDto;
        }

        public IEnumerable<PaisDto> GetAll()
        {
            return ConvertirListaAListaDto(_repositorio.GetAll());
        }

        public void Remove(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Update(string nombre, PaisDto paisDto)
        {
            throw new NotImplementedException();
        }

        public PaisDto GetPaisByIso(Pais pais)
        {                 
 
        PaisDto paisD = new PaisDto(pais);
            return paisD;

        }
}
}
