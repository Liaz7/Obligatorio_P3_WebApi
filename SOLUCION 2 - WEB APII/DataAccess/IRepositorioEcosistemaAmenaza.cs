using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositorioEcosistemaAmenaza : IRepositorio<EcosistemaAmenaza>
    {
        public IEnumerable<EcosistemaAmenaza> GetAll();

        public IEnumerable<EcosistemaAmenaza> GetById(string ecosistema);


    }
}
