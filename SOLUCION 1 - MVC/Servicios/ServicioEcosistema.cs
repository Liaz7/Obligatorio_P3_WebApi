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
        private IRepositorioEstadoDeConservacion _repositorioEstados;


        public ServicioEcosistema(IRepositorioEcosistema repositorio, IRepositorioPais repositorioPais, IRepositorioEcosistemaEspecie repositorioEspecie, IRepositorioEcosistemaAmenaza repositorioEcosistemaAmenaza, IRepositorioUbicacionGeografica repositorioUbicacionGeografica, IRepositorioEstadoDeConservacion repositorioEstados)
        {
            _repositorio = repositorio;
            _repositorioPais = repositorioPais;
            _repositorioEcosistemaEspecie = repositorioEspecie;
            _repositorioEcosistemaAmenaza = repositorioEcosistemaAmenaza;
            _repositorioUbicacionGeografica = repositorioUbicacionGeografica;
            _repositorioEstados = repositorioEstados;
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
                List<EcosistemaAmenaza> ListaEcosistemaAmenazas = new List<EcosistemaAmenaza>();
                List<EcosistemaEspecie> ListaEcosistenaEspecie = new List<EcosistemaEspecie>();
                ecosistema.Validar();

                


                foreach (int amenaza in ecosistemaDto.AmenazasIds)
                {
                    ListaEcosistemaAmenazas.Add(new EcosistemaAmenaza(amenaza, ecosistemaDto.EcNombre));
                }

                foreach (string especie in ecosistemaDto.EspecieIds)
                {
                    ListaEcosistenaEspecie.Add(new EcosistemaEspecie(especie, ecosistemaDto.EcNombre, false));
                }

                ecosistema.EcosistemaAmenaza = ListaEcosistemaAmenazas;
                ecosistema.EcosistemaEspecie = ListaEcosistenaEspecie;
                IEnumerable<EstadoDeConservacion> estados = _repositorioEstados.GetById(ecosistema.EstadoDeConservacionId);
                foreach (EstadoDeConservacion estado in estados)
                {
                    if (estado.ConsId == ecosistema.EstadoDeConservacionId)
                    {
                        ecosistema.EstadoDeConservacion = estado;
                    }
                }

                IEnumerable<Pais> paises = _repositorioPais.GetByAlias(ecosistema.PaisId);
                foreach (Pais pais in paises)
                {
                    if (pais.PaisIso == ecosistema.PaisId)
                    {
                        ecosistema.Pais = pais;
                    }
                }

                Ecosistema newEcosistema = _repositorio.Add(ecosistema);
                EcosistemaDto newEcosistemaDto = new EcosistemaDto(newEcosistema);
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
