using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositorioEcosistemaEspecie : IRepositorio<EcosistemaEspecie>
    {
        public bool getCompartenAmenazas(string especie, string ecosistema);

        public IEnumerable<EcosistemaEspecie> GetAll();

        public IEnumerable<EcosistemaEspecie> GetById(string ecosistema);
    }
}
