using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Dto;
using Dominio.Entidades.Interfaces;

namespace Dominio.Entidades
{
    public class Usuario : IValidable
    {
        public int UsId;
        public string UsuarioAlias;
        public string UsuarioContrasenia;

        public Usuario() { }

        public Usuario(UsuarioDto usuarioDto) 
        { 
            this.UsuarioAlias = usuarioDto.UsuarioAlias;
            this.UsuarioContrasenia = usuarioDto.UsuarioContrasenia;  
        }

        public void Copy(UsuarioDto usuarioDto)
        {
            this.UsuarioAlias = usuarioDto.UsuarioAlias;
            this.UsuarioContrasenia = usuarioDto.UsuarioContrasenia;
            
        }

        public virtual void Validar()
        {
            ValidarMail();
            ValidarContrasenia();
        }

        private void ValidarMail()
        {

            bool esValido = UsuarioAlias.Length >= 6;

            if (!esValido) { throw new Exception("Ingrese un correo electronico valido"); }
        }

        private void ValidarContrasenia()
        {
            if (string.IsNullOrEmpty(UsuarioContrasenia) || UsuarioContrasenia.Length < 8) { throw new Exception("La contraseña debe contener al menos 8 caracteres"); }
        }

        public override bool Equals(object? obj)
        {
            Usuario u = obj as Usuario;
            return u != null && this.UsuarioAlias.Equals(u.UsuarioAlias);
        }

        public virtual string GetRol()
        {
            return "operador";
        }

    }
}
