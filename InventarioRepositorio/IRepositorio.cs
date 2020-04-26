using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventarioRepositorio
{
    public interface IRepositorio<T> where T: class
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> TraerTodo();
        IEnumerable<T> Buscar(Expression<Func<T,bool>> predicado);

        T TraerUno(Expression<Func<T, bool>> predicado);
        T TraerUnoPorID(int Id);

        void Adicionar(T entidad);
        void Modificar(T entidad);
        void Eliminar(T entidad);

        void Grabar();
    }
}
