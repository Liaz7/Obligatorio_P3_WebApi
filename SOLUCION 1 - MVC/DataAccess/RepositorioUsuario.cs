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
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        /*public RepositorioUsuario(DbContext dbContext)
        {
            Context = dbContext;
        }*/

        private IRestContext<Usuario> _restContext;

        public RepositorioUsuario(IRestContext<Usuario> restContext)
        {
            //_repositoryTipoRest = new RestContextLogin("https://localhost:7111/api/Usuarios");
            _restContext = restContext;
        }

        /*public Usuario GetById(int id)
        {
            return Context.Set<Usuario>().FirstOrDefault(usuario => usuario.UsId == id);
        }*/

        /*public IEnumerable<Usuario> GetByAlias(string alias)
        {
            return Context.Set<Usuario>().Where(usuario => usuario.UsuarioAlias.Contains(alias));
        }*/

        public Usuario Add(Usuario entity)
        {
            
           return _restContext.AddUsuario(entity).GetAwaiter().GetResult();
        }


        public Usuario GetUsuarioByAlias(string alias)
        {
            IEnumerable<Usuario> usuarios = _restContext.GetAll("").GetAwaiter().GetResult();
            Usuario usuario = null;
            foreach (Usuario user in usuarios)
            {
                if (user.UsuarioAlias == alias)
                {
                    usuario = user;
                }
            }

            return usuario;
        }

        public UsuarioDto Login(UsuarioDto loginDto)
        {
            return _restContext.Login(loginDto).GetAwaiter().GetResult();

        }
    }
}
