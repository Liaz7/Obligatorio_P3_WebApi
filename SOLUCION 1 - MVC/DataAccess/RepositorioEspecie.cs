using DataAccess;
using Dominio.Dto;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RepositorioEspecie : Repositorio<Especie>, IRepositorioEspecie
{
    private IRestContext<Especie> _restContext;

    public RepositorioEspecie(IRestContext<Especie> restContext)
    {
        _restContext = restContext;
    }

    public IEnumerable<Especie> GetByNombreCientifico(string nombreCientifico)
    {
        String filters = "/listarEspeciesPorNombreCientifico?nombreCientifico="; //eje para un filtro ?variable=valor , para 2 filtros ?variable=valor&variable2=valor2

        string nombreCientificoEscapado = Uri.EscapeDataString(nombreCientifico);

        filters = filters + nombreCientificoEscapado;

        return _restContext.GetAll(filters).GetAwaiter().GetResult();
    }

    public IEnumerable<Especie> GetAll()
    {
        String filters = "/listarEspecies"; //eje para un filtro ?variable=valor , para 2 filtros ?variable=valor&variable2=valor2
        return _restContext.GetAll(filters).GetAwaiter().GetResult();
    }
    
    /*
    public IEnumerable<Especie> GetByRango(decimal pesoMinimo, decimal pesoMaximo)
    {
        String filters = "/listarEspeciesPorRango?pesoMinimo="; //eje para un filtro ?variable=valor , para 2 filtros ?variable=valor&variable2=valor2
        filters = filters + pesoMinimo + "&pesoMaximo=" + pesoMaximo;
        return _restContext.GetAll(filters).GetAwaiter().GetResult();
    }

    /*public Especie GetOneByNombreCientifico(string nombreCientifico)
    {
        return Context.Set<Especie>().FirstOrDefault(especie => especie.EsNombreCientifico == nombreCientifico);
    }

    public IEnumerable<Especie> GetEspeciesEnPeligroDeExtincion()
    {
        IEnumerable<Especie> especiesEnPeligroDeExtincion = (
            from e in Context.Set<Especie>()
            join ee in Context.Set<EcosistemaEspecie>() on e.EsNombreCientifico equals ee.EsNombreCientifico
            join ea in Context.Set<EcosistemaAmenaza>() on ee.EcNombre equals ea.EcNombre where e.EstadoDeConservacionId == "2"
               || (Context.Set<EcosistemaAmenaza>().Count(ea => ea.EcNombre == ee.EcNombre) > 3
                   || Context.Set<EcosistemaEspecie>().Count(ea => ea.EcNombre == ea.EcNombre) > 3)
               && Context.Set<Ecosistema>().Any(ec => ec.EcNombre == ee.EcNombre && ec.EstadoDeConservacionId == "2")
            select e
        ).Distinct().ToList();

        return especiesEnPeligroDeExtincion;
    }

    public Especie GetByNombre(string nombre)
    {
        return Context.Set<Especie>().FirstOrDefault(eo => eo.EsNombreCientifico == nombre);
    }

    public IEnumerable<Especie> GetByNombreEcosistema(string ecNombre)
    {
        return (
            from e in Context.Set<Especie>()
            join ee in Context.Set<EcosistemaEspecie>() on e.EsNombreCientifico equals ee.EsNombreCientifico
            where ee.Habitan == true && ee.EcNombre == ecNombre
            select e
        ).Distinct().ToList();
    }*/
}
