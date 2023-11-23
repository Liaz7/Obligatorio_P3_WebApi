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
        public Ecosistema GetByEcosisitema(Ecosistema eco)
        {
            return Context.Set<Ecosistema>().FirstOrDefault(ecosistema => ecosistema.EcNombre == eco.EcNombre);
        }

        public IEnumerable<Ecosistema> GetAll()
        {
            return Context.Set<Ecosistema>().ToList();
        }

        public void EliminarEnCascada(Ecosistema ecosistema)
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
