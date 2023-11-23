using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioEstadoDeConservacion : Repositorio<EstadoDeConservacion>, IRepositorioEstadoDeConservacion
    {
        private IRestContext<EstadoDeConservacion> _restContext;

        public RepositorioEstadoDeConservacion(IRestContext<EstadoDeConservacion> restContext)
        {
            _restContext = restContext;
        }
        public IEnumerable<EstadoDeConservacion> GetAll()
        {
            String filters = "/listarEstados";
            return _restContext.GetAll(filters).GetAwaiter().GetResult();
        }

        public IEnumerable<EstadoDeConservacion> GetById(string consId)
        {
            String filters = "/listarEstados?consId="; //eje para un filtro ?variable=valor , para 2 filtros ?variable=valor&variable2=valor2

            string nombreCientificoEscapado = Uri.EscapeDataString(consId);

            filters = filters + nombreCientificoEscapado;

            return _restContext.GetAll(filters).GetAwaiter().GetResult();
        }
    }
}
