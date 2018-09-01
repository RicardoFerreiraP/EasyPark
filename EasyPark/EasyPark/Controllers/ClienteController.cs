using EasyPark.DAL;
using EasyPark.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace EasyPark.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClientesCadastrados()
        {
            return View(ClienteDAO.ListarTodosClientes());
        }

        public ActionResult CadastrarCliente()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCliente(Cliente cliente, HttpPostedFileBase fupImagem)
        {

            if (ModelState.IsValid)
            {

                if (fupImagem != null)
                {
                    string nomeImagem = Path.GetFileName(fupImagem.FileName);
                    string caminho = Path.Combine(Server.MapPath("~/Images/"), nomeImagem);
                    fupImagem.SaveAs(caminho);
                    cliente.Imagem = nomeImagem;
                }
                else
                {
                    cliente.Imagem = "semimagem.jpg";
                }
                ClienteDAO.CadastrarCliente(cliente);
                return RedirectToAction("ClientesCadastrados");
            }
            else
            {
                return View(cliente);
            }
        }

        public ActionResult AlterarCliente(int id)
        {
            return View(ClienteDAO.BuscarClientePorID(id));
        }

        [HttpPost]
        public ActionResult AlterarCliente(Cliente clienteAlterado)
        {
            Cliente clienteOriginal = ClienteDAO.BuscarClientePorID(clienteAlterado.ClienteID);

            clienteOriginal.Nome     = clienteAlterado.Nome;
            clienteOriginal.CPF      = clienteAlterado.CPF;
            clienteOriginal.Telefone = clienteAlterado.Telefone;
            clienteOriginal.Email    = clienteAlterado.Email;

            if (ModelState.IsValid)
            {
                ClienteDAO.AlterarCliente(clienteOriginal);
                return RedirectToAction("ClientesCadastrados", "Cliente");
               
            }
            else
            {
                return View(clienteOriginal);
            }
        }
        public ActionResult RemoverCliente(int id)
        {
            ClienteDAO.RemoverCliente(id);
            return RedirectToAction("ClientesCadastrados", "Cliente");
        }
    }
}