using Microsoft.EntityFrameworkCore;
using ProyectoEmpleo.DAL.DBContext;
using ProyectoEmpleo.DAL.Repositorio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleo.DAL.Repositorio
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbEmpleoContext _dbcontext;
        public GenericRepository(DbEmpleoContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Task<IQueryable<T>> consultar(Expression<Func<T, bool>> filtro = null)
        {
            try
            {
                var querymodel=filtro==null? _dbcontext.Set<T>() : _dbcontext.Set<T>().Where(filtro);
                return Task.FromResult(querymodel);
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> crear(T modelo)
        {
            try
            {
                _dbcontext.Set<T>().Add(modelo);
                await _dbcontext.SaveChangesAsync();
                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public Task<bool> editar(T modelo)
        {
            try
            {
                _dbcontext.Set<T>().Update(modelo);
                _dbcontext.SaveChanges();
                return Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> eliminar(T modelo)
        {
            try
            {
                _dbcontext.Set<T>().Remove(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public Task<T> obtener(Expression<Func<T, bool>> filtro)
        {
            try
            {
                T querymodel =_dbcontext.Set<T>().Where(filtro).FirstOrDefault()!;
                return Task.FromResult(querymodel);
            }
            catch
            {
                throw;
            }
        }
    }
}
