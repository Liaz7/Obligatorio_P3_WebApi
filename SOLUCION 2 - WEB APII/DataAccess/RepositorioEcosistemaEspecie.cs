using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp;

namespace DataAccess
{
    public class RepositorioEcosistemaEspecie : Repositorio<EcosistemaEspecie>, IRepositorioEcosistemaEspecie
    {
        public RepositorioEcosistemaEspecie(DbContext dbContext)
        {
            Context = dbContext;
        }

        public EcosistemaEspecie Add(EcosistemaEspecie entity)
        {
            Context.Set<EcosistemaEspecie>().Add(entity);
            return entity;
        }


        public void Remove(EcosistemaEspecie entity)
        {
            Context.Set<EcosistemaEspecie>().Remove(entity);
        }


        public void Update(EcosistemaEspecie entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<EcosistemaEspecie> GetAll()
        {
            return Context.Set<EcosistemaEspecie>().ToList();
        }

        public IEnumerable<EcosistemaEspecie> GetById(string ecosistema)
        {
            return Context.Set<EcosistemaEspecie>().Where(ea => ea.EcNombre == ecosistema).ToList();
        }


        public void Save()
        {
            Context.SaveChanges();
        }

        public bool getCompartenAmenazas(string especie, string ecosistema)
        {
           return (from ea in Context.Set<EspecieAmenaza>()
             join ec in Context.Set<EcosistemaAmenaza>() on ea.AmId equals ec.AmId
             where ea.EcNombre == especie
                   && ec.EcNombre == ecosistema
             select ea).Any();
        }
    }
}
