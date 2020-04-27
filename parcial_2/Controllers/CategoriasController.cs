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
    public class CategoriasController : Controller
    {

        public ActionResult Index()
        {
            var _categorias = new dominio.Categorias().CategoriasList();
            return View(_categorias);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            var categoria = new entidades.Categorias();
            return PartialView("Crear", categoria);
        }

        [HttpPost]
        public ActionResult Crear(entidades.Categorias categoria)
        {
            new dominio.Categorias().CrearCategoria(categoria);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var _categoria = new dominio.Categorias().CategoriasPorId(id);
            return PartialView(_categoria);
        }

        [HttpPost]
        public ActionResult Editar(entidades.Categorias categoriaEditada)
        {
            new dominio.Categorias().ModificarCategoria(categoriaEditada);
            return RedirectToAction("Index");
        }
    }
}