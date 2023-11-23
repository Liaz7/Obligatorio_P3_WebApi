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

        public ServicioUsuario(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;

        }

        public UsuarioDto Login(UsuarioDto usuarioDto)

        {
            try
            {
                // Obtén el usuario desde el repositorio por el alias del usuarioDto
                Usuario usuario = _repositorio.GetUsuarioByAlias(usuarioDto.UsuarioAlias);

                // Verifica si el usuario no es nulo y si coincide con los datos proporcionados en usuarioDto
                if (usuario != null && usuarioDto.UsuarioContrasenia == usuario.UsuarioContrasenia)
                {
                     // Los datos coinciden, crea un nuevo UsuarioDto y devuélvelo
                    UsuarioDto newUsuarioDto = new UsuarioDto(usuario);
                    return newUsuarioDto;
                }else {
                    throw new Exception("La contrasenia o el usuario no son correctos.");
                }

                
            }
            catch (Exception ex)
            {
                throw new ElementoNoEncontradoException(ex.Message);
            }
        }

        public UsuarioDto Add(UsuarioDto usuarioDto)
        {
            usuarioDto.Validar();
            Usuario usuario = new Usuario(usuarioDto);
            Usuario newUsuario = _repositorio.Add(usuario);
            UsuarioDto newUsuarioDto = new UsuarioDto(newUsuario);
            return newUsuarioDto;
        }

        public UsuarioDto GetById(int id)
        {
            Usuario usuario = _repositorio.GetById(id);
            ThrowExceptionIfNotFound(usuario);
            UsuarioDto usuarioDto = new UsuarioDto(usuario);
            return usuarioDto;
        }

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
        public IEnumerable<UsuarioDto> GetByAlias(string name)
        {
            List<UsuarioDto> usuariosDto = new List<UsuarioDto>();
            IEnumerable<Usuario> usuarios = _repositorio.GetByAlias(name);
            foreach (Usuario usuario in usuarios)
            {
                UsuarioDto usuarioDto = new UsuarioDto(usuario);
                usuariosDto.Add(usuarioDto);
            }
            return usuariosDto;
        }

        public void Remove(int id)
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
        }
    }
}
