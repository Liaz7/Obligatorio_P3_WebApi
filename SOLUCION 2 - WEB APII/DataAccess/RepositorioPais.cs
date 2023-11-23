using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioPais : Repositorio<RepositorioPais>, IRepositorioPais
    {
        public RepositorioPais(DbContext dbContext)
        {
            Context = dbContext;
        }

        public Pais Add(Pais entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> GetAll()
        {
            return Context.Set<Pais>().ToList();
        }

        public IEnumerable<Pais> GetByAlias(string pais)
        {
            return Context.Set<Pais>().Where(usuario => usuario.EcIsoPais.Contains(pais));
        }

        public Pais GetByNombre(string pais)
        {
            return Context.Set<Pais>().FirstOrDefault(eo => eo.EcIsoPais == pais);
        }

        

        public void Remove(Pais entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais entity)
        {
            throw new NotImplementedException();
        }
    }
}
