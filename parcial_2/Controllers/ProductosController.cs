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
    
        [HttpGet]
        public ActionResult Crear()
        {
            var producto = new entidades.Productos();
            return PartialView("Crear", producto);
        }

        [HttpPost]
        public ActionResult Crear(entidades.Productos producto)
        {
            new dominio.Productos().CrearProducto(producto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _producto = new dominio.Productos().ProductosPorId(id);
            return PartialView(_producto);
        }

        [HttpPost]
        public ActionResult Editar(entidades.Productos productoEditado)
        {
            new dominio.Productos().ModificarProducto(productoEditado);
            return RedirectToAction("Index");
        }

        public IEnumerable<SelectListItem> getCategorias()
        {
            var dbCategorias = new dominio.Categorias();
            var categorias = dbCategorias
                        .CategoriasList()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.id_categoria.ToString(),
                                    Text = x.nombre
                                });

            return new SelectList(categorias, "Value", "Text");
        }
    }
}