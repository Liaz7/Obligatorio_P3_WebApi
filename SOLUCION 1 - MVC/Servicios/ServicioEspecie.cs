using DataAccess;
using Dominio.Dto;
using Dominio.Entidades;
using Dominio.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioEspecie : IServicioEspecie
    {
        private IRepositorioEspecie _repositorio;
        private IRepositorioEspecieAmenaza _repositorioEspecieAmenaza;
        private IRepositorioEcosistemaEspecie _repositorioEcosistemaEspecie;
        private IConfiguration _configuration;
        public ServicioEspecie(IRepositorioEspecie repositorio, IRepositorioEspecieAmenaza repositorioEspecieAmenaza, IRepositorioEcosistemaEspecie repositorioEcosistemaEspecie, IConfiguration configuration)
        {
            _repositorio = repositorio;
            _repositorioEspecieAmenaza = repositorioEspecieAmenaza;
            _repositorioEcosistemaEspecie = repositorioEcosistemaEspecie;
            _configuration = configuration;
        }

        private void ThrowExceptionIfNotFound(Especie especie)
        {
            if (especie == null)
            {
                throw new ElementoNoEncontradoException("No se encontro la especie");
            }
        }

        private IEnumerable<EspecieDto> ConvertirListaAListaDto(IEnumerable<Especie> especies)
        {
            List<EspecieDto> especiesDto = new List<EspecieDto>();
            foreach (Especie especie in especies)
            {
                EspecieDto especieDto = new EspecieDto(especie);
                especiesDto.Add(especieDto);
            }
            return especiesDto;
        }
        public EspecieDto Add(EspecieDto EspecieDto)
        {
            try
            {
                Especie especie = new Especie(EspecieDto);
                especie.Validar();
                Especie newEspecie = _repositorio.Add(especie);


                foreach (int amenaza in EspecieDto.AmenazasIds)
                {
                    EspecieAmenaza especieAmenaza = new EspecieAmenaza(amenaza, EspecieDto.EsNombreCientifico);
                    _repositorioEspecieAmenaza.Add(especieAmenaza);
                }

                foreach (string eco in EspecieDto.EcosistemasIdsTe)
                {
                    EcosistemaEspecie ecosistemaEspecie = new EcosistemaEspecie(EspecieDto.EsNombreCientifico, eco, false);
                    _repositorioEcosistemaEspecie.Add(ecosistemaEspecie);
                }

                EspecieDto newEspecieDto = new EspecieDto(newEspecie);
                _repositorio.Save();
                _repositorioEspecieAmenaza.Save();
                _repositorioEcosistemaEspecie.Save();
                return newEspecieDto;
            }
            catch (Exception ex)
            {
                string hashCode = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                if (hashCode.Contains("PK_Especies"))
                {
                    throw new ElementoNoValidoException("Ya existe una Especie con el mismo Nombre.");
                }
                else
                {
                    throw new ElementoNoValidoException(ex.Message);
                }
            }
            
        }

        public IEnumerable<EspecieDto> GetAll()
        {
            return ConvertirListaAListaDto(_repositorio.GetAll());
        }


       /* public IEnumerable<EspecieDto> GetByRango(decimal rangoMinimo, decimal rangoMaximo)
        {
            return ConvertirListaAListaDto(_repositorio.GetByRango(rangoMinimo, rangoMaximo));
        }*/

/*public IEnumerable<EspecieDto> GetByNombreCientifico(string nombreCientifico)
{
    return ConvertirListaAListaDto(_repositorio.GetByNombreCientifico(nombreCientifico));

}

public void Update(string nombreCientifico, EspecieDto especieDto)
{
    especieDto.Validar();
    Especie especie = _repositorio.GetOneByNombreCientifico(nombreCientifico);
    ThrowExceptionIfNotFound(especie);
    especie.CopyEspecie(especieDto);
    _repositorio.Update(especie);
    _repositorio.Save();
}*/
/*
public void Remove(string nombreCientifico)
{
throw new NotImplementedException();
}

public IEnumerable<EspecieDto> GetEspeciesEnPeligroDeExtincion()
{
return ConvertirListaAListaDto(_repositorio.GetEspeciesEnPeligroDeExtincion());
}

public EspecieDto GetOneByNombreCientifico(string nombreCientifico)
{
Especie especie = _repositorio.GetOneByNombreCientifico(nombreCientifico);
ThrowExceptionIfNotFound(especie);
EspecieDto especieDto = new EspecieDto(especie);
return especieDto;
}

public IEnumerable<EspecieDto> GetByNombreEcosistema(string ecNombre)
{
return ConvertirListaAListaDto(_repositorio.GetByNombreEcosistema(ecNombre));
}*/

}
}