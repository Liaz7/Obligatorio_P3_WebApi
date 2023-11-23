using Dominio.Dto;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositorioAmenaza : Repositorio<Amenaza>, IRepositorioAmenaza
    {
        private IRestContext<Amenaza> _restContext;

        public RepositorioAmenaza(IRestContext<Amenaza> restContext)
        {
            //_repositoryTipoRest = new RestContextLogin("https://localhost:7111/api/especies");
            _restContext = restContext;
        }
        public IEnumerable<Amenaza> GetAll()
        {
             String filters = "/listarAmenazas"; //eje para un filtro ?variable=valor , para 2 filtros ?variable=valor&variable2=valor2
             return _restContext.GetAll(filters).GetAwaiter().GetResult();
        }

        /*public Amenaza GetById(int id)
        {
            return Context.Set<Amenaza>().FirstOrDefault(am => am.AmId == id);
        }*/
    }
}
