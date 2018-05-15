using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        Colegio colegioEntities = new Colegio();
        
        public ActionResult Index()
        {
            //List<Persona> listp = new List<Persona>();

            //Persona p1 = new Persona();
            //p1.id = 1;
            //p1.nombre = "juan";
            //p1.apePater = "condi";
            //p1.apeMater = "tipula";
            //listp.Add(p1);
            //Persona p2 = new Persona();
            //p2.id = 1;
            //p2.nombre = "juan";
            //p2.apePater = "condi";
            //p2.apeMater = "tipula";

            //listp.Add(p2);

            //Persona p3 = new Persona();
            //p3.id = 1;
            //p3.nombre = "juan";
            //p3.apePater = "condi";
            //p3.apeMater = "tipula";

            //listp.Add(p3);


            var listCargo = colegioEntities.cargo;

            return View(listCargo.ToList());
        }


        public ActionResult listMuestraCargo() {
            var listCargo = colegioEntities.cargo;
            return View(listCargo.ToList());
        }


        public ActionResult usuarioxCargo(string cargo) {
            var usuario = from p in colegioEntities.usuario where p.cargo.car_des == cargo select p;

            return View(usuario.ToList());
        }

        public ActionResult mostrarUsuarioConCargo() {
            var modelo = from p in colegioEntities.usuario
                         join c in colegioEntities.cargo on p.car_cod equals c.car_cod
                         select new Persona
                         {
                             codigo = p.usu_cod,
                             nombre = p.usu_nom,
                             cargo = c.car_des
                         };
                               

                         

            return View(modelo.ToList());
        }


    }
}