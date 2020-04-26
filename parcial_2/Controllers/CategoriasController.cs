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

    }
}