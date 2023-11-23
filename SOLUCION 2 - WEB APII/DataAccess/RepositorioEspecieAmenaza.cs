using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioEspecieAmenaza : Repositorio<EspecieAmenaza>, IRepositorioEspecieAmenaza
    {
        public RepositorioEspecieAmenaza(DbContext dbContext)
        {
            Context = dbContext;
        }

        public EspecieAmenaza Add(EspecieAmenaza entity)
        {
            Context.Set<EspecieAmenaza>().Add(entity);
            return entity;
        }


        public void Remove(EspecieAmenaza entity)
        {
            Context.Set<EspecieAmenaza>().Remove(entity);
        }


        public void Update(EspecieAmenaza entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }


        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
