using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioEcosistemaAmenaza : Repositorio<EcosistemaAmenaza>, IRepositorioEcosistemaAmenaza
    {
        public RepositorioEcosistemaAmenaza(DbContext dbContext)
        {
            Context = dbContext;
        }

        public EcosistemaAmenaza Add(EcosistemaAmenaza entity)
        {
            Context.Set<EcosistemaAmenaza>().Add(entity);
            return entity;
        }

        public IEnumerable<EcosistemaAmenaza> GetAll()
        {
            return Context.Set<EcosistemaAmenaza>().ToList();
        }

       

        public void Remove(EcosistemaAmenaza entity)
        {
            Context.Set<EcosistemaAmenaza>().Remove(entity);
        }


        public void Update(EcosistemaAmenaza entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }


        public void Save()
        {
            Context.SaveChanges();
        }

        public IEnumerable<EcosistemaAmenaza> GetById(string ecosistema)
        {
            return Context.Set<EcosistemaAmenaza>().Where(ea => ea.EcNombre == ecosistema).ToList();
        }

    }
}
