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

        public ActionResult OcuparVaga(int id)
        {
            Vaga vaga = VagaDAO.BuscarVagaPorId(id);
            Historico historico = new Historico
            {              
                Vaga = vaga,
                DataEntrada = DateTime.Now
            };
            return View(historico);
        }
        
        [HttpPost]
        public ActionResult OcuparVaga(Historico historico, string placa)
        {
            if(ModelState.IsValid)
            {
                historico.Automovel = AutomovelDAO.BuscaAutomovelPorPlaca(placa);
                historico.Vaga = VagaDAO.BuscarVagaPorId(historico.Vaga.VagaID);
                if (HistoricoDAO.CarroEstacionado(historico) == null)
                {

                    if (AutomovelDAO.BuscaAutomovelPorPlaca(placa) != null)
                    {
                        HistoricoDAO.OcuparVaga(historico);
                        VagaDAO.AlterarVaga(historico.Vaga.VagaID);

                    }
                    else
                    {
                        ModelState.AddModelError("", "Não existe um carro com essa placa!!");
                        return View(historico);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Este carro já está estacionado!!");
                    return View(historico);
                }
               
               
            }
            else
            {
                return View(historico);
            }
            
            return RedirectToAction("MostrarVagas", "Historico");
        }

        public ActionResult VagaDetalhes(int id)
        {
           
            return View( HistoricoDAO.DetalhesVaga(id));
        }

        public ActionResult Finalizar(int id)
        {

            Historico historico = HistoricoDAO.BuscarHistoricoPorVagaId(id);
            historico.DataSaida = DateTime.Now;
            HistoricoDAO.Finalizar(historico);
            VagaDAO.Finalizado(id);
            return RedirectToAction("MostrarVagas", "Historico");
        }
    }
}