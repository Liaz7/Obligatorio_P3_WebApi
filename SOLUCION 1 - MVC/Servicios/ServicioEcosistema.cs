using DataAccess;
using Dominio.Dto;
using Dominio.Entidades;
using Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioEcosistema : IServicioEcosistema
    {
        private IRepositorioEcosistema _repositorio;
        private IRepositorioPais _repositorioPais;
        private IRepositorioEcosistemaEspecie _repositorioEcosistemaEspecie;
        private IRepositorioEcosistemaAmenaza _repositorioEcosistemaAmenaza;
        private IRepositorioUbicacionGeografica _repositorioUbicacionGeografica;


        public ServicioEcosistema(IRepositorioEcosistema repositorio, IRepositorioPais repositorioPais, IRepositorioEcosistemaEspecie repositorioEspecie, IRepositorioEcosistemaAmenaza repositorioEcosistemaAmenaza, IRepositorioUbicacionGeografica repositorioUbicacionGeografica)
        {
            _repositorio = repositorio;
            _repositorioPais = repositorioPais;
            _repositorioEcosistemaEspecie = repositorioEspecie;
            _repositorioEcosistemaAmenaza = repositorioEcosistemaAmenaza;
            _repositorioUbicacionGeografica = repositorioUbicacionGeografica;
        }

        private void ThrowExceptionIfNotFound(Ecosistema eco)
        {
            if (eco == null)
            {
                throw new ElementoNoEncontradoException("No se encontro el Ecosistema");
            }
        }

        private IEnumerable<EcosistemaDto> ConvertirListaAListaDto(IEnumerable<Ecosistema> ecosistemas)
        {
            List<EcosistemaDto> ecosistemasDto = new List<EcosistemaDto>();
            foreach (Ecosistema eco in ecosistemas)
            {
                EcosistemaDto ecosistemaDto = new EcosistemaDto(eco);
                ecosistemasDto.Add(ecosistemaDto);
            }
            return ecosistemasDto;
        }


        public EcosistemaDto Add(EcosistemaDto ecosistemaDto)
        {
            try {
                Ecosistema ecosistema = new Ecosistema(ecosistemaDto);
                ecosistema.Validar();

                /*_repositorioUbicacionGeografica.Add(ecosistemaDto.EcUbicacionGeografica);
                _repositorioUbicacionGeografica.Save();

                UbicacionGeografica ubicacionGeografica = _repositorioUbicacionGeografica.GetByLatitudYLongitud(ecosistema.EcUbicacionGeografica.Latitud, ecosistema.EcUbicacionGeografica.Longitud);
                ecosistema.EcUbicacionGeograficaId = ubicacionGeografica.UbicacionGeograficaId;*/
                Ecosistema newEcosistema = _repositorio.Add(ecosistema);


                /*foreach (int amenaza in ecosistemaDto.AmenazasIds)
                {
                    EcosistemaAmenaza ecosistemaAmenaza = new EcosistemaAmenaza(amenaza, ecosistemaDto.EcNombre);
                    _repositorioEcosistemaAmenaza.Add(ecosistemaAmenaza);
                }

                foreach (string especie in ecosistemaDto.EspecieIds)
                {
                    EcosistemaEspecie ecosistemaEspecie = new EcosistemaEspecie(especie, ecosistemaDto.EcNombre, false);
                    _repositorioEcosistemaEspecie.Add(ecosistemaEspecie);
                }*/


                EcosistemaDto newEcosistemaDto = new EcosistemaDto(newEcosistema);

                /*_repositorioEcosistemaAmenaza.Save();
                _repositorioEcosistemaEspecie.Save();*/
                _repositorio.Save();

                return newEcosistemaDto;
            }
            catch(Exception ex){
                throw new ElementoNoValidoException(ex.Message);
            }
        }

        /*public IEnumerable<EcosistemaDto> GetAll()
        {
            return ConvertirListaAListaDto(_repositorio.GetAll());
        }

        public IEnumerable<EcosistemaDto> GetByNombreEspecie(string nombre)
        {
            return ConvertirListaAListaDto(_repositorio.GetByNombreEspecie(nombre));
        }

        public EcosistemaDto GetByNombre(string nombre)
        {
            Ecosistema eco = _repositorio.GetByNombre(nombre);
            EcosistemaDto ecoDto = new EcosistemaDto(eco);
            return ecoDto;
        }

        public EcosistemaDto GetById(int id)
        {
            Ecosistema ecosistema = _repositorio.GetById(id);
            ThrowExceptionIfNotFound(ecosistema);
            EcosistemaDto ecosistemaDto = new EcosistemaDto(ecosistema);
            return ecosistemaDto;
        }

        public void EliminarEnCascada(EcosistemaDto ecosistemaDto)
        {
            ecosistemaDto.Validar();
            Ecosistema newEcosistema = _repositorio.GetByNombre(ecosistemaDto.EcNombre);
            _repositorio.EliminarEnCascada(newEcosistema);
        }

        public void Update(string nombre, EcosistemaDto ecosistemaDto)
        {
            ecosistemaDto.Validar();
            Ecosistema eco = _repositorio.GetByNombre(nombre);
            ThrowExceptionIfNotFound(eco);
            eco.CopyEcosistema(ecosistemaDto);
            _repositorio.Update(eco);
            _repositorio.Save();
        }*/
            }
}
