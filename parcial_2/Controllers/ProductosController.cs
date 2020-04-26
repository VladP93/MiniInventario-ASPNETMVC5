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
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            var _productos = new dominio.Productos().ProductosList();
            return View(_productos);
        }
    }
}