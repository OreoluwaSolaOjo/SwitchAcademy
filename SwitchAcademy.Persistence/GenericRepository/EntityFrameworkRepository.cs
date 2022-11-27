using Microsoft.EntityFrameworkCore;
using SwitchAcademy.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.GenericRepository
{
    public class EntityFrameworkRepository<T> : IEntityFrameworkRepository<T> where T : class
    {
        private readonly DataContext _context;

        public EntityFrameworkRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T model)
        {
            try
            {
                await _context.Set<T>().AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(T model)
        {
            try
            {
                _context.Set<T>().Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return  _context.Set<T>().AsNoTracking();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task<T> GetById(int id)
        //{
        //    try
        //    {
        //        return await _context.Set<T>().Find(id);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task Update(T model)
        {
            try
            {
                _context.Set<T>().Update(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private async Task SaveChanges()
        {

        }
    }
}
