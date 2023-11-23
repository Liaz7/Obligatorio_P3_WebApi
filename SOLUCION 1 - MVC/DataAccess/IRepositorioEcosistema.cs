using Dominio.Dto;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositorioEcosistema
    {

        Ecosistema Add(Ecosistema entity);
        void EliminarEnCascada(Ecosistema ecosistema);
        IEnumerable<Ecosistema> GetAll();

        Ecosistema GetByNombre(string nombre);

        /*
        Ecosistema GetByEcosisitema(Ecosistema eco);
        IEnumerable<Ecosistema> GetByNombreEspecie(string ecNombre);
        IEnumerable<Ecosistema> GetAll();
       
        

        Ecosistema GetById(int id);*/


    }
}
