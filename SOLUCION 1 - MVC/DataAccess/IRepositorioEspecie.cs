using DataAccess;
using Dominio.Dto;
using Dominio.Entidades;
using System;

public interface IRepositorioEspecie : IRepositorio<Especie>
{
    IEnumerable<Especie> GetByNombreCientifico(string nombreCientifico);

    IEnumerable<Especie> GetByNombreEcosistema(string ecNombre);

    IEnumerable<Especie> GetAll();

    Especie GetOneByNombreCientifico(string nombreCientifico);
    
    Especie GetByNombre(string nombre);

    ICollection<Especie> GetByRango(decimal pesoMinimo, decimal pesoMaximo);

    IEnumerable<Especie> GetEspeciesEnPeligroDeExtincion();
}
