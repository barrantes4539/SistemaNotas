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
    }
}