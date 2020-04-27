using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using entidades = InventarioEntidades;
using dominio = InventarioDominio;

namespace parcial_2.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            var _clientes = new dominio.Clientes().CLientesList();
            return View(_clientes);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            var cliente = new entidades.Clientes();
            return PartialView("Crear", cliente);
        }

        [HttpPost]
        public ActionResult Crear(entidades.Clientes cliente)
        {
            new dominio.Clientes().CrearCliente(cliente);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _cliente = new dominio.Clientes().ClientesPorId(id);
            return PartialView(_cliente);
        }

        [HttpPost]
        public ActionResult Editar(entidades.Clientes clienteEditado)
        {
            new dominio.Clientes().ModificarCliente(clienteEditado);
            return RedirectToAction("Index");
        }
    }
}