using Dominio.Dto;
using Dominio.Entidades;

namespace Servicios
{
    public interface IServicioEspecie
    {
       /* EspecieDto Add(EspecieDto EspecieDto);
        void Update(string nombreCientifico, EspecieDto especieDto);
        void Remove(string nombreCientifico);
        IEnumerable<EspecieDto> GetByNombreCientifico(string nombreCientifico);
        EspecieDto GetOneByNombreCientifico(string nombreCientifico);
        IEnumerable<EspecieDto> GetByNombreEcosistema(string ecNombre);*/
        IEnumerable<EspecieDto> GetAll();

       /*
        IEnumerable<EspecieDto> GetEspeciesEnPeligroDeExtincion();
        IEnumerable<EspecieDto> GetByRango(decimal rangoMinimo, decimal rangoMaximo);*/
    }
}