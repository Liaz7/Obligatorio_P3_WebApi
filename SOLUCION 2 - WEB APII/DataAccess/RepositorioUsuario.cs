using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(DbContext dbContext)
        {
            Context = dbContext;
        }
        public Usuario GetById(int id)
        {
            return Context.Set<Usuario>().FirstOrDefault(usuario => usuario.UsId == id);
        }

        public IEnumerable<Usuario> GetByAlias(string alias)
        {
            return Context.Set<Usuario>().Where(usuario => usuario.UsuarioAlias.Contains(alias));
        }

        public Usuario GetUsuarioByAlias(string alias)
        {
            return Context.Set<Usuario>().FirstOrDefault(usuario => usuario.UsuarioAlias == alias);
        }
    }
}
