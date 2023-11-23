using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioPais : Repositorio<Pais>, IRepositorioPais
    {
        private IRestContext<Pais> _restContext;

        public RepositorioPais(IRestContext<Pais> restContext)
        {
            _restContext = restContext;
        }

        /*public Pais Add(Pais entity)
        {
            throw new NotImplementedException();
        }*/

        public IEnumerable<Pais> GetAll()
        {
            String filters = ""; //eje para un filtro ?variable=valor , para 2 filtros ?variable=valor&variable2=valor2
            return _restContext.GetAll(filters).GetAwaiter().GetResult();
        }

        /*public IEnumerable<Pais> GetByAlias(string pais)
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
        }*/
    }
}
