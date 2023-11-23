using Dominio.Dto;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepositorioAmenaza : IRepositorio<Amenaza>
    {
        IEnumerable<Amenaza> GetAll();

        Amenaza GetById(int id);
    }
}
