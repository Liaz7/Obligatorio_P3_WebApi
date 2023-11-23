using Dominio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRestContext<T>
    {
        Task<IEnumerable<T>> GetAll(String filters);
        Task<IEnumerable<T>> GetAllWoFilters();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
        Task<T> Add(T entity);
        Task<bool> Update(int id, T entity);
        Task<bool> Remove(int id);

        Task<UsuarioDto> Login(UsuarioDto entity);
    }
}
