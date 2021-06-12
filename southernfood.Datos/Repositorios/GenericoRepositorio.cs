using southernfood.Data.Models;
using southernfood.Datos.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace southernfood.Datos.Repositorios
{
    public class GenericoRepositorio<T> : IGenericoRepositorio<T> where T :class
    {
        private RestauranteDbContext _dbContext = new RestauranteDbContext();

        public async Task<T> Add(T t)
        {
              _dbContext.Entry(t).State = EntityState.Added;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return t;
        }

        public async Task<bool> Delete(int id)
        {
            var t = await _dbContext.Set<T>().FindAsync(id);
            
            _dbContext.Entry(t).State = EntityState.Deleted;
            try
            {
                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<T> Find(int? id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<bool> Update(T t)
        {
            _dbContext.Set<T>().Attach(t);
            _dbContext.Entry(t).State = EntityState.Modified;
            try
            {
                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }    
        }

        public Task<bool> Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
