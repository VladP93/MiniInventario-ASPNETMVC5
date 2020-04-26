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
    public class Categorias
    {
        private Repositorio<db.categoria> _repositorio = new Repositorio<db.categoria>(new db.parcial2Entities());

        public IEnumerable<entidades.Categorias> CategoriasList()
        {
            var _consultaDB = _repositorio.TraerTodo();
            var _categorias = Mapper.Map<IEnumerable<db.categoria>, IEnumerable<entidades.Categorias>>(_consultaDB);
            return _categorias;
        }

        public entidades.Categorias CategoriasPorId(int id)
        {
            var _consultaDB = _repositorio.TraerUnoPorID(id);
            var _categoria = Mapper.Map<db.categoria, entidades.Categorias>(_consultaDB);
            return _categoria;
        }

        public void CrearCategoria(entidades.Categorias _CategoriaCrear)
        {
            var _categoria = Mapper.Map<entidades.Categorias, db.categoria>(_CategoriaCrear);
            _repositorio.Adicionar(_categoria);
            _repositorio.Grabar();
        }

        public void ModificarCategoria(entidades.Categorias _CategoriaModificar)
        {
            var _categoria = Mapper.Map<entidades.Categorias, db.categoria>(_CategoriaModificar);
            _repositorio.Modificar(_categoria);
            _repositorio.Grabar();
        }

        public void EliminarCategoria(entidades.Categorias _CategoriaEliminar)
        {
            var _categoria = Mapper.Map<entidades.Categorias, db.categoria>(_CategoriaEliminar);
            _repositorio.Eliminar(_categoria);
            _repositorio.Grabar();
        }

        public IEnumerable<entidades.Categorias> BuscarCategorias(Expression<Func<db.categoria, bool>> predicadoBusqueda)
        {
            var _consultaDb = _repositorio.Buscar(predicadoBusqueda);
            var _categoriasEncontradas = Mapper.Map<IEnumerable<db.categoria>, IEnumerable<entidades.Categorias>>(_consultaDb);
            return _categoriasEncontradas;
        }

        public entidades.Categorias BuscarUnaCategoria(Expression<Func<db.categoria,bool>> predicadoBusqueda)
        {
            var _consultaDb = _repositorio.TraerUno(predicadoBusqueda);
            var _categoriaEncontrada = Mapper.Map<db.categoria, entidades.Categorias>(_consultaDb);
            return _categoriaEncontrada;
        }

    }
}
