using SistemaNotas.Models.Entidades;
using SistemaNotas.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaNotas.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult InicioSesion(string correo, string password)
        //{
        //    Estudiantes usuarios = new Usuarios();
        //    string mensaje = usuarios.VerificarCredenciales(correo, password);

        //    if (mensaje == "Acceso concedido")
        //    {
        //        // Si el login es exitoso, almacenamos el correo electrónico del usuario en una variable de sesión.
        //        Session["correoUsuarioTemporal"] = correo;
        //        Console.WriteLine(usuarios.IdUsuarioLogueado(correo));
        //        Session["idUsuario"] = usuarios.IdUsuarioLogueado(correo);


        //        bool respuesta = EnviarVerificacion(Session["correoUsuarioTemporal"].ToString(), out mensaje);

        //        return RedirectToAction("Index", "Home"); // Redireccionar a una página de bienvenida o dashboard después del login exitoso.
        //    }
        //    else
        //    {
        //        // Mostrar el mensaje de error en el div "errorDiv" en la vista Login.
        //        ViewBag.ErrorMessage = mensaje;
        //        return View();
        //    }
        //}

        [HttpPost]
        public ActionResult IniciarSesion(string correo, string contrasena)
        {
            CD_Estudiante datosUsuarios = new CD_Estudiante();
            object loginResult = datosUsuarios.IniciarSesion(correo, contrasena);

            if (loginResult is Estudiantes estudiante)
            {
                // Successfully logged in as a student
                Session["correoEstudiante"] = estudiante.Correo; // Store student's email in session
                return RedirectToAction("Index", "Estudiante", new { id = estudiante.IdEstudiante });
            }
            else if (loginResult is Profesores profesor)
            {
                // Successfully logged in as a professor
                Session["correoProfesor"] = profesor.Correo; // Store professor's email in session
                return RedirectToAction("Index", "Profesor", new { id = profesor.IdProfesor });
            }
            else if (loginResult.ToString() == "0")
            {
                // Invalid login
                TempData["ErrorMessage"] = "Invalid email or password.";
            }
            else
            {
                // Error occurred during login
                TempData["ErrorMessage"] = "An error occurred during login.";
            }

            return RedirectToAction("Index", "Home"); // Redirect to login page
        }
    }
}
