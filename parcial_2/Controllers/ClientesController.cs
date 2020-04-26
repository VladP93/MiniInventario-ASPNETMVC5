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
    }
}