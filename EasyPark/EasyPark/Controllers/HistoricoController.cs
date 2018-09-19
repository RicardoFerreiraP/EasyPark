using EasyPark.DAL;
using EasyPark.Models;
using System;
using System.Web.Mvc;

namespace EasyPark.Controllers
{
    public class HistoricoController : Controller
    {
        // GET: Historico
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarVagas()
        {
            return View(VagaDAO.RetornarVagas());
        }

        public ActionResult  OcuparVaga(int id)
        {
            int idVaga = VagaDAO.BuscarVagaPorIdVaga(id);
            ViewBag.VagaId = idVaga;
            return View();
        }
        
        [HttpPost]
        public ActionResult OcuparVaga(Historico historico, string placa, int id)
        {
            if(ModelState.IsValid)
            {
                historico.Vaga.VagaID = id;
                historico.Automovel = AutomovelDAO.BuscaAutomovelPorPlaca(placa);
                historico.DataEntrada = DateTime.Now;
                HistoricoDAO.OcuparVaga(historico);
                VagaDAO.AlterarVaga(historico.Vaga.VagaID);
            }
            
            return RedirectToAction("MostrarVagas", "Historico");
        }
    }
}