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
            if (Session["correoProfesor"] != null || Session["correoEstudiante"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginApp", "AccesoApp");
            }
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
            if (Session["correoEstudiante"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginApp", "AccesoApp");
            }
        }

        public ActionResult VerEstudiantes()
        {
            if (Session["correoProfesor"] != null)
            {
                List<Estudiante_ProfesorMateria> estudiantes = CD_Profesor.CargarNotasEstudiante(Convert.ToInt32(Session["idProfesor"]));
                return View(estudiantes);
            }
            else
            {
                return RedirectToAction("LoginApp", "AccesoApp");
            }

        }

        public ActionResult VerMateriasEstudiantes()
        {
            return View();
        }
        public ActionResult ModificarNotas()
        {
            if (Session["correoProfesor"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginApp", "AccesoApp");
            }
        }

 
    }
}