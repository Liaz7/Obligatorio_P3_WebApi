﻿using Dominio.Dto;
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
    public RepositorioEspecie(DbContext dbContext)
    {
        Context = dbContext;
    }
    public IEnumerable<Especie> GetByNombreCientifico(string nombreCientifico)
    {
        return Context.Set<Especie>().Where(especie => especie.EsNombreCientifico.Contains(nombreCientifico)).ToList();
    }

    public IEnumerable<Especie> GetAll()
    {
        return Context.Set<Especie>().ToList();
    }

    public ICollection<Especie> GetByRango(decimal pesoMinimo, decimal pesoMaximo)
    {
        ICollection<Especie> especiesEnRango = Context.Set<Especie>()
        .Where(especie => especie.EsPesoMinimo >= pesoMinimo && especie.EsPesoMaximo <= pesoMaximo)
        .ToList();

        return especiesEnRango;
    }

    public Especie GetOneByNombreCientifico(string nombreCientifico)
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
    }
}
