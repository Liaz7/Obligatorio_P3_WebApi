using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioEcosistema : Repositorio<Ecosistema>, IRepositorioEcosistema
    {
        public RepositorioEcosistema(DbContext dbContext)
        {
            Context = dbContext;
        }

        private IRestContext<Ecosistema> _restContext;

        public RepositorioEcosistema(IRestContext<Ecosistema> restContext)
        {
            //_repositoryTipoRest = new RestContextLogin("https://localhost:7111/api/Usuarios");
            _restContext = restContext;
        }
        public Ecosistema GetByEcosisitema(Ecosistema eco)
        {
            return Context.Set<Ecosistema>().FirstOrDefault(ecosistema => ecosistema.EcNombre == eco.EcNombre);
        }

        public IEnumerable<Ecosistema> GetAll()
        {
            String filters = "/listarEcosistemas"; //eje para un filtro ?variable=valor , para 2 filtros ?variable=valor&variable2=valor2

            

            return _restContext.GetAll(filters).GetAwaiter().GetResult();
        }

        public void EliminarEnCascada(Ecosistema  ecosistema)
        {
            if (ecosistema != null)
            {
                Context.Entry(ecosistema).State = EntityState.Deleted;
                Context.SaveChanges();
                Context.Remove(ecosistema);
            }
               

        }

        public Ecosistema GetById(int id)
        {
            return Context.Set<Ecosistema>().FirstOrDefault(ecosistema => ecosistema.EcUbicacionGeograficaId == id);
        }

        public Ecosistema GetByNombre(string nombre)
        {
            return Context.Set<Ecosistema>().FirstOrDefault(eco => eco.EcNombre == nombre);
        }

        public IEnumerable<Ecosistema> GetByNombreEspecie(string ecNombre)
        {
            return Context.Set<Ecosistema>()
                .Where(e => Context.Set<Especie>()
                    .Any(es => es.EsNombreCientifico == ecNombre) && // Verifica si la especie existe
                    !Context.Set<EcosistemaEspecie>()
                        .Where(ee => ee.EsNombreCientifico == ecNombre)
                        .Select(ee => ee.EcNombre)
                        .Contains(e.EcNombre) &&
                    !Context.Set<EcosistemaAmenaza>()
                        .Where(ea => ea.EcNombre == e.EcNombre)
                        .Any(ea => Context.Set<EcosistemaEspecie>()
                            .Where(ee => ee.EsNombreCientifico == ecNombre)
                            .Select(ee => ee.EcNombre)
                            .Contains(ea.EcNombre)))
                .ToList();
        }
    }
}
