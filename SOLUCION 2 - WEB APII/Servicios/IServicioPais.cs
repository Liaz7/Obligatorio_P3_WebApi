using Dominio.Dto;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IServicioPais
    {
        PaisDto Add(PaisDto paisDto);
        void Update(string nombre, PaisDto paisDto);
        void Remove(string nombre);
        PaisDto GetPaisByIso(Pais pais);
        IEnumerable<PaisDto> GetAll();
    }
}
