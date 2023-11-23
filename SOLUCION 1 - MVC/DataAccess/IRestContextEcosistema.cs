using Dominio.Dto;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRestContextEcosistema
    {
        Task<Ecosistema> Add(Ecosistema entity);

        Task<IEnumerable<Ecosistema>> GetAll(string filters);
    }
}
