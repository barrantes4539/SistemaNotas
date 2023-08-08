﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
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