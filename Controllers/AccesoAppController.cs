﻿using SistemaNotas.Models.Entidades;
using SistemaNotas.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaNotas.Controllers
{
    public class AccesoAppController : Controller
    {
        // GET: AccesoApp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InicioSesionApp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InicioSesionApp(string correo, string password)
        {
            CD_Estudiante loginProcessor = new CD_Estudiante();
            object loginResult = loginProcessor.IniciarSesion(correo, password);

            if (loginResult is Estudiantes estudiante)
            {
                // Successfully logged in as a student
                Session["correoEstudiante"] = estudiante.Correo; // Store student's email in session
                return RedirectToAction("Index", "Home", new { id = estudiante.IdEstudiante });
            }
            else if (loginResult is Profesores profesor)
            {
                // Successfully logged in as a professor
                Session["correoProfesor"] = profesor.Correo; // Store professor's email in session
                return RedirectToAction("Index", "Home", new { id = profesor.IdProfesor });
            }
            else if (loginResult.ToString() == "0")
            {
                ViewBag.ErrorMessage = "Correo o contraseña inválidos.";
            }
            else
            {
                ViewBag.ErrorMessage = "Error al iniciar sesión.";
            }

            return View("InicioSesionApp"); // Return back to the login view
        }
    }
}
    