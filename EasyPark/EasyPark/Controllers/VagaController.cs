using EasyPark.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyPark.Controllers
{
    public class VagaController : Controller
    {
        // GET: Vaga
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetalhesVaga()
        {
            return View();
        }

        public ActionResult OcuparVaga()
        {
            return View();
        }
    }
}