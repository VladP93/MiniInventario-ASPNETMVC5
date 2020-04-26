using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventarioRepositorio
{
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        private readonly DbContext _context;

        public Repositorio(DbContext contexto)
        {
            _context = contexto;
        }

        public void Adicionar(T entidad)
        {
            _context.Set<T>().Add(entidad);
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().AsNoTracking().Where(predicado);
        }

        public void Dispose()
        {
            return;
        }

        public void Eliminar(T entidad)
        {
            _context.Entry<T>(entidad).State = EntityState.Deleted;
        }

        public void Grabar()
        {
            _context.SaveChanges();
        }

        public void Modificar(T entidad)
        {
            _context.Entry<T>(entidad).State = EntityState.Modified;
        }

        public IEnumerable<T> TraerTodo()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T TraerUno(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().AsNoTracking().Where(predicado).FirstOrDefault();
        }

        public T TraerUnoPorID(int Id)
        {
            return _context.Set<T>().Find(Id);
        }
    }
}
