using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BLL
{
    interface IRepository<T> where T : class
    {
        bool Guardar(T entity);
        bool Modificar(T entity);
        bool Eliminar(int id);
        T Buscar(int id);
        List<T> GetList(Expression<Func<T, bool>> expression);
    }
}
