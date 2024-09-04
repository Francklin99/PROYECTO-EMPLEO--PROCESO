using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEmpleo.DAL.Repositorio.Contrato
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> obtener(Expression<Func<T, bool>> filtro);
        Task<T> crear(T modelo);
        Task<bool> editar(T modelo);
        Task<bool> eliminar(T modelo);
        Task<IQueryable<T>> consultar(Expression<Func<T, bool>> filtro=null!);

    }
}
