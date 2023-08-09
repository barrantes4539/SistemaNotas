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
                List<VistaNotas> notas = CD_Estudiante.CargarNotasEstudiante(Convert.ToInt32(Session["idEstudiante"]));
                return View(notas); // Pasar el modelo a la vista
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
        public ActionResult ModificarNotas(int? idEstudiante)
        {
            if (Session["correoProfesor"] != null)
            {
                if (idEstudiante.HasValue)
                {
                    Estudiante_ProfesorMateria estudiante = CD_Profesor.ObtenerEstudiantePorId(idEstudiante.Value);

                    ViewBag.IdEstudiante = estudiante.IdEstudiante;
                    ViewBag.IdMateriaEstudiante = estudiante.IdEstudianteProfesorMateria;
                    ViewBag.Nota = estudiante.Nota;
                    ViewBag.Estado = estudiante.Estado;
                }

                return View();
            }
            else
            {
                return RedirectToAction("LoginApp", "AccesoApp");
            }
        }

        [HttpGet]
        public JsonResult CargarDatosEstudiante(int id)
        {
            Estudiante_ProfesorMateria estudiante = CD_Profesor.ObtenerEstudiantePorId(id); // Reemplaza esto con tu método real
            var data = new
            {
                IdEstudiante = estudiante.IdEstudiante,
                Estado = estudiante.Estado,
                Nota = estudiante.Nota
                // Otros campos del estudiante que necesitas
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerEstudiantePorId(int id)
        {
            try
            {
                Estudiante_ProfesorMateria estudiante = CD_Profesor.ObtenerEstudiantePorId(id);
                if (estudiante != null)
                {
                    return Json(estudiante, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { error = "Estudiante no encontrado" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ProcesarModificarNotas(int idEstudiante, string estado, double nota)
        {
            if (Session["correoProfesor"] != null)
            {
                bool modificacionExitosa = CD_Profesor.ModificarNotasEstudiante(idEstudiante, estado, nota);

                if (modificacionExitosa)
                {
                    TempData["SuccessMessage"] = "Notas del estudiante modificadas exitosamente.";
                }
                else
                {
                    TempData["ErrorMessage"] = "No se pudieron modificar las notas del estudiante.";
                }

                return RedirectToAction("VerEstudiantes"); // Redirigir a la página de ver estudiantes o a donde desees
            }
            else
            {
                return RedirectToAction("LoginApp", "AccesoApp");
            }
        }









    }
}