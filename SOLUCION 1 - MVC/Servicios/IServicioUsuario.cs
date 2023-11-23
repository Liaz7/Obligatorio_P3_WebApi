using Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IServicioUsuario
    {
        UsuarioDto Add(UsuarioDto usuarioDto);
      /*  void Update(int id, UsuarioDto usuarioDto);
        void Remove(int id);
        UsuarioDto GetById(int id);
        IEnumerable<UsuarioDto> GetByAlias(string alias);*/
        UsuarioDto GetUsuarioDtoByAlias(string alias);
        public UsuarioDto Login(UsuarioDto usuarioDto);
    }
}
