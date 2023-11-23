using Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRestContextLogin
    {

        Task<UsuarioDto> Login(UsuarioDto entity);

    }
}
