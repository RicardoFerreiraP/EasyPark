using EasyPark.DAL;
using EasyPark.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace EasyPark.Controllers
{
    public class AutomovelController : Controller
    {
        // GET: Automovel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AutomoveisCadastrados()
        {
            return View(AutomovelDAO.ListarTodosAutomoveis());
        }

        public ActionResult CadastrarAutomovel()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarAutomovel(Automovel automovel, string Clientes, HttpPostedFileBase fupImagem)
        {

            if (ModelState.IsValid)
            {
                automovel.Cliente = ClienteDAO.BuscarClientePorCPF(Clientes);
                if (ClienteDAO.BuscarClientePorCPF(Clientes) == null)
                {
                    ModelState.AddModelError("", "Não existe um cliente com este CPF!!");
                }           
            
                else if (AutomovelDAO.CadastrarAutomovel(automovel))
                {

                    return RedirectToAction("ClientesCadastrados", "Cliente");
                }
                else
                {
                    ModelState.AddModelError("", "Já existe um Automovel com esta Placa!!");
                }
                    return View(automovel);
            }
            else
            {
                return View(automovel);
            }
        }

        public ActionResult RemoverAutomovel(int id)
        {
            AutomovelDAO.RemoverAutomovel(id);
            return RedirectToAction("AutomovelCadastrados", "Automovel");
        }
    }
}