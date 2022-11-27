using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.GenericRepository
{
    public interface IEntityFrameworkRepository<T> where T : class 
    {
        Task AddAsync(T model);
        IQueryable<T> GetAll();
        Task Delete(T model);
        Task Update(T model);
        //Task<T> GetById(int id);
    }
}
