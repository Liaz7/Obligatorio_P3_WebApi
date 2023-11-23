using DataAccess;
using Dominio.Dto;
using Dominio.Entidades;
using System;

public interface IRepositorioEspecie : IRepositorio<Especie>
{
    IEnumerable<Especie> GetByNombreCientifico(string nombreCientifico);

    IEnumerable<Especie> GetAll();

    IEnumerable<Especie> GetByRango(decimal pesoMinimo, decimal pesoMaximo);

}
