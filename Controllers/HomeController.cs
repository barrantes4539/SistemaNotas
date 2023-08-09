using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaNotas.Models.Entidades;
using SistemaNotas.Models.BD;

namespace SistemaNotas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult VerMaterias()
        {
            List<VistaNotas> notas = CD_Estudiante.CargarNotasEstudiante(Convert.ToInt32(Session["idEstudiante"]));
            return View(notas);
        }

        public ActionResult VerEstudiantes()
        {
            return View();
        }

        public ActionResult VerMateriasEstudiantes()
        {
            return View();
        }
        public ActionResult ModificarNotas()
        {
            return View();
        }

 
    }
}