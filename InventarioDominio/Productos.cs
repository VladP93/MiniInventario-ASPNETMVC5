using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = InventarioDataBase;
using entidades = InventarioEntidades;
using InventarioRepositorio;
using System.Linq.Expressions;

namespace InventarioDominio
{
    public class Productos
    {
        private Repositorio<db.producto> _repositorio = new Repositorio<db.producto>(new db.parcial2Entities());

        public IEnumerable<entidades.Productos> ProductosList()
        {
            var _consultaDB = _repositorio.TraerTodo();
            var _productos = Mapper.Map<IEnumerable<db.producto>, IEnumerable<entidades.Productos>>(_consultaDB);
            return _productos;
        }

        public entidades.Productos ProductosPorId(int id)
        {
            var _consultaDB = _repositorio.TraerUnoPorID(id);
            var _producto = Mapper.Map<db.producto, entidades.Productos>(_consultaDB);
            return _producto;
        }

        public void CrearProducto(entidades.Productos _ProductoCrear)
        {
            var _producto = Mapper.Map<entidades.Productos, db.producto>(_ProductoCrear);
            _repositorio.Adicionar(_producto);
            _repositorio.Grabar();
        }

        public void ModificarProducto(entidades.Productos _ProductoModificar)
        {
            var _producto = Mapper.Map<entidades.Productos, db.producto>(_ProductoModificar);
            _repositorio.Modificar(_producto);
            _repositorio.Grabar();
        }

        public void EliminarProducto(entidades.Productos _ProductoEliminar)
        {
            var _producto = Mapper.Map<entidades.Productos, db.producto>(_ProductoEliminar);
            _repositorio.Eliminar(_producto);
            _repositorio.Grabar();
        }

        public IEnumerable<entidades.Productos> BuscarProducto(Expression<Func<db.producto, bool>> predicadoBusqueda)
        {
            var _consultaDb = _repositorio.Buscar(predicadoBusqueda);
            var _productosEncontrados = Mapper.Map<IEnumerable<db.producto>, IEnumerable<entidades.Productos>>(_consultaDb);
            return _productosEncontrados;
        }

        public entidades.Productos BuscarUnProducto(Expression<Func<db.producto, bool>> predicadoBusqueda)
        {
            var _consultaDb = _repositorio.TraerUno(predicadoBusqueda);
            var _productoEncontrado = Mapper.Map<db.producto, entidades.Productos>(_consultaDb);
            return _productoEncontrado;
        }

    }
}
