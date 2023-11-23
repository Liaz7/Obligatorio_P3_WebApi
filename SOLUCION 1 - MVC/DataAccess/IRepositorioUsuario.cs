using Dominio.Dto;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
       // IEnumerable<Usuario> GetByAlias(string alias);

        Usuario GetUsuarioByAlias(string alias);

        public UsuarioDto Login(UsuarioDto loginDto);

       // Usuario GetById(int id);
    }
}
