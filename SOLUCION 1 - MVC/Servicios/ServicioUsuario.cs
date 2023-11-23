using DataAccess;
using Dominio.Dto;
using Dominio.Entidades;
using Dominio.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {
        private IRepositorioUsuario _repositorio;
        private IRestContext<Usuario> _restContext;

        public ServicioUsuario(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;

        }

        public UsuarioDto Login(UsuarioDto usuarioDto)

        {

 
            try
            {
                UsuarioDto usuario = _repositorio.Login(usuarioDto);
                //grabo token
                return usuario;

            }
            catch (ElementoNoValidoException ex)
            {
                throw new ElementoNoValidoException(ex.Message);
            }
        }

        public UsuarioDto Add(UsuarioDto usuarioDto)
        {
            usuarioDto.Validar();
            Usuario usuario = new Usuario(usuarioDto);
            Usuario newUsuario = _repositorio.Add(usuario);
            _repositorio.Save();
            UsuarioDto newUsuarioDto = new UsuarioDto(newUsuario);
            return newUsuarioDto;
        }

        /*  public UsuarioDto GetById(int id)
          {
              Usuario usuario = _repositorio.GetById(id);
              ThrowExceptionIfNotFound(usuario);
              UsuarioDto usuarioDto = new UsuarioDto(usuario);
              return usuarioDto;
          }*/

        public UsuarioDto GetUsuarioDtoByAlias(string alias)
        {
            Usuario usuario = _repositorio.GetUsuarioByAlias(alias);
            ThrowExceptionIfNotFound(usuario);
            UsuarioDto usuarioDto = new UsuarioDto(usuario);
            return usuarioDto;
        }

        private void ThrowExceptionIfNotFound(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ElementoNoEncontradoException("No se encontro el usuario");
            }
        }
        /* public IEnumerable<UsuarioDto> GetByAlias(string name)
         {
             List<UsuarioDto> usuariosDto = new List<UsuarioDto>();
             IEnumerable<Usuario> usuarios = _repositorio.GetByAlias(name);
             foreach (Usuario usuario in usuarios)
             {
                 UsuarioDto usuarioDto = new UsuarioDto(usuario);
                 usuariosDto.Add(usuarioDto);
             }
             return usuariosDto;
         }*/

        /* public void Remove(int id)
         {
             Usuario usuario = _repositorio.GetById(id);
             ThrowExceptionIfNotFound(usuario);
             _repositorio.Remove(usuario);
             _repositorio.Save();
         }

         public void Update(int id, UsuarioDto usuarioDto)
         {
             usuarioDto.Validar();
             Usuario usuario = _repositorio.GetById(id);
             ThrowExceptionIfNotFound(usuario);

             usuario.Copy(usuarioDto);
             _repositorio.Update(usuario);
             _repositorio.Save();
         }*/
    }
}
