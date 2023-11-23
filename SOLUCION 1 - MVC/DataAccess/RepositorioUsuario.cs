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

        public Usuario GetUsuarioByAlias(string alias)
        {
           /* String filters = "?"; //eje para un filtro ?variable=valor , para 2 filtros ?variable=valor&variable2=valor2

            filters = filters + "UsuarioAlias=" + alias;*/

            return _restContext.GetByName(alias).GetAwaiter().GetResult();
        }

        public UsuarioDto Login(UsuarioDto loginDto)
        {
            return _restContext.Login(loginDto).GetAwaiter().GetResult();

        }
    }
}
