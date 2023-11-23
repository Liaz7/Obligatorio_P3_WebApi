using Dominio.Dto;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositorioEcosistema : IRepositorio<Ecosistema>
    {
        Ecosistema GetByEcosisitema(Ecosistema eco);

        IEnumerable<Ecosistema> GetAll();

        IEnumerable<Ecosistema> GetByNombreEspecie(string ecNombre);
        Ecosistema GetByNombre(string nombre);

        Ecosistema GetById(int id);

        void EliminarEnCascada(Ecosistema ecosistema);
    }
}
