using Dominio.Dto;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioAmenaza : Repositorio<Amenaza>, IRepositorioAmenaza
    {
        public RepositorioAmenaza(DbContext dbContext)
        {
            Context = dbContext;
        }
        public IEnumerable<Amenaza> GetAll()
        {
            return Context.Set<Amenaza>().ToList();
        }

        public Amenaza GetById(int id)
        {
            return Context.Set<Amenaza>().FirstOrDefault(am => am.AmId == id);
        }
    }
}
