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
    public class Clientes
    {
        private Repositorio<db.cliente> _repositorio = new Repositorio<db.cliente>(new db.parcial2Entities());

        public IEnumerable<entidades.Clientes> CLientesList()
        {
            var _consultaDB = _repositorio.TraerTodo();
            var _clientes = Mapper.Map<IEnumerable<db.cliente>, IEnumerable<entidades.Clientes>>(_consultaDB);
            return _clientes;
        }

        public entidades.Clientes ClientesPorId(int id)
        {
            var _consultaDB = _repositorio.TraerUnoPorID(id);
            var _cliente = Mapper.Map<db.cliente, entidades.Clientes>(_consultaDB);
            return _cliente;
        }

        public void CrearCliente(entidades.Clientes _ClienteCrear)
        {
            var _cliente = Mapper.Map<entidades.Clientes, db.cliente>(_ClienteCrear);
            _repositorio.Adicionar(_cliente);
            _repositorio.Grabar();
        }

        public void ModificarCliente(entidades.Clientes _ClienteModificar)
        {
            var _cliente = Mapper.Map<entidades.Clientes, db.cliente>(_ClienteModificar);
            _repositorio.Modificar(_cliente);
            _repositorio.Grabar();
        }

        public void EliminarCliente(entidades.Clientes _ClienteEliminar)
        {
            var _cliente = Mapper.Map<entidades.Clientes, db.cliente>(_ClienteEliminar);
            _repositorio.Eliminar(_cliente);
            _repositorio.Grabar();
        }

        public IEnumerable<entidades.Clientes> BuscarClientea(Expression<Func<db.cliente, bool>> predicadoBusqueda)
        {
            var _consultaDb = _repositorio.Buscar(predicadoBusqueda);
            var _clientesEncontrados = Mapper.Map<IEnumerable<db.cliente>, IEnumerable<entidades.Clientes>>(_consultaDb);
            return _clientesEncontrados;
        }

        public entidades.Clientes BuscarUnCliente(Expression<Func<db.cliente, bool>> predicadoBusqueda)
        {
            var _consultaDb = _repositorio.TraerUno(predicadoBusqueda);
            var _clienteEncontrado = Mapper.Map<db.cliente, entidades.Clientes>(_consultaDb);
            return _clienteEncontrado;
        }

    }
}
