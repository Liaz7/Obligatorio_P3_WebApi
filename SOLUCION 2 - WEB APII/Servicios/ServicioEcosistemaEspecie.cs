using DataAccess;
using Dominio.Entidades;
using Dominio.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioEcosistemaEspecie : IServicioEcosistemaEspecie
    {
        private IRepositorioEcosistema _repositorioEcosistema;
        private IRepositorioEspecie _repositorioEspecie;
        private IRepositorioEcosistemaEspecie _repositorioEcosistemaEspecie;

        public ServicioEcosistemaEspecie(IRepositorioEcosistema repositorioEcosistema, IRepositorioEspecie repositorioEspecie, IRepositorioEcosistemaEspecie repositorioEcosistemaEspecie)
        {
            _repositorioEcosistema = repositorioEcosistema;
            _repositorioEspecie = repositorioEspecie;
            _repositorioEcosistemaEspecie = repositorioEcosistemaEspecie;
        }
        public EcosistemaEspecie AddEcosistemaEspecie(string nombreEspecie, string nombreEcosistema)
        {
            try
            {
                Ecosistema ecosistema = _repositorioEcosistema.GetByNombre(nombreEcosistema);
                Especie especie = _repositorioEspecie.GetByNombre(nombreEspecie);
                if (_repositorioEcosistemaEspecie.getCompartenAmenazas(nombreEspecie, nombreEcosistema)) throw new Exception("Tanto la Especie como el Ecosistema comparten Amenazas");

                if (int.Parse(ecosistema.EstadoDeConservacionId) < int.Parse(especie.EstadoDeConservacionId)) throw new Exception("El Estado de Conservacion del Ecosistema es peor que el de la Especie");
                EcosistemaEspecie newEcosistemaEspecie = new EcosistemaEspecie(nombreEspecie, nombreEcosistema, true);

                _repositorioEcosistemaEspecie.Add(newEcosistemaEspecie);
                _repositorioEcosistemaEspecie.Save();
                return newEcosistemaEspecie;
            }
            catch (Exception ex)
            {
                string hashCode = ex.InnerException.Message;
                if (hashCode.Contains("PK_EcosistemaEspecie")) {
                    throw new ElementoNoValidoException("La Especie ya se encuentra dentro del Ecosistema al cual quiere asignarla.");
                }
                else
                {
                    throw new ElementoNoValidoException(ex.Message);
                }
            }
        }
    }
}
