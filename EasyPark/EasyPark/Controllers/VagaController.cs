using EasyPark.DAL;
using EasyPark.Models;
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
            return View(VagaDAO.RetornarVagas());
        }

        public ActionResult DetalhesVaga()
        {
            return View();
        }

        public ActionResult CadastrarVaga()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarVaga([Bind(Include = "VagaID, Disponivel")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                    VagaDAO.CadastrarVaga(vaga);
                    return RedirectToAction("MostrarVagas", "Historico");
            }
            else
            {
                return View(vaga);
            }
        }

    }
}