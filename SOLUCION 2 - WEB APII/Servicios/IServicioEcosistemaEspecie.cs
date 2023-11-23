using Dominio.Dto;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IServicioEcosistemaEspecie
    {
        EcosistemaEspecie AddEcosistemaEspecie(string nombreEcosistema, string nombreEspecie);
    }
}
