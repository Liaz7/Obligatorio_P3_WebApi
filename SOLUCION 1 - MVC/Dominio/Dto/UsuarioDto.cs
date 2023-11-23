using Dominio.Entidades;
using Dominio.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dominio.Dto
{
    public class UsuarioDto : IValidable
    {
        [JsonIgnore]
        public int UsuarioId { get; set; }
        [JsonInclude]
        public string UsuarioAlias { get; set; }
        [JsonInclude]
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
