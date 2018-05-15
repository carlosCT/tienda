using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Dao;

namespace PruebaTecnica.Controllers
{
    public class ProductoController : Controller
    {
        Model1 colegioEntities = new Model1();
        // GET: Producto


        public ActionResult Index(String nombre, string idProducto)
        {
            ViewBag.idProducto = new SelectList(colegioEntities.producto,"idProducto", "nombre", "precio");
            var producto = from p in colegioEntities.producto select p;
             if (!String.IsNullOrEmpty(nombre)) {
                producto= producto.Where(n => n.nombre.Contains(nombre));
             }


            if (!String.IsNullOrEmpty(idProducto))
            {
                int v = Convert.ToInt32(idProducto);

                return View(producto.Where(x => x.idProducto == v));
            }
            else {
                return View(producto);
            }
            return View(producto);
        }


        public ActionResult addPedido(int producto) {
            ProductoDao pDao = new ProductoDao();
            pDao.CreateTemporaryOrder(1, producto);

            var sproducto = colegioEntities.producto;
            return View(sproducto.ToList());
        }
    }
}