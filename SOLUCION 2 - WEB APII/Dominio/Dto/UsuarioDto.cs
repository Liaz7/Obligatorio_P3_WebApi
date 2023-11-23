using Dominio.Entidades;
using Dominio.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class UsuarioDto : IValidable
    {
        public int UsuarioId { get; set; }
        public string UsuarioAlias { get; set; }
        public string UsuarioContrasenia { get; set; }

        public UsuarioDto() { }

        public UsuarioDto(Usuario usuario) 
        {
            this.UsuarioAlias = usuario.UsuarioAlias;
            this.UsuarioContrasenia = usuario.UsuarioContrasenia;
        }

        public void Validar() 
        {
            
        }
    }
}
