using EasyPark.DAL;
using EasyPark.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
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

        [Authorize]
        public ActionResult ClientesCadastrados()
        {
            string url = "http://localhost:50171/api/Cliente/Clientes";
            WebClient client = new WebClient();
            string json = client.DownloadString(url);
            byte[] bytes = Encoding.Default.GetBytes(json);
            json = Encoding.UTF8.GetString(bytes);
            List<Cliente> listCliente = JsonConvert.DeserializeObject<List<Cliente>>(json);

            return View(listCliente);
        }

        [Authorize]
        public ActionResult CadastrarCliente()
        {

            return View();
        }
       
        [Authorize]
        [HttpPost]
        public ActionResult CadastrarCliente([Bind(Include = "ClienteID, Nome, CPF, Telefone, Email")] Cliente cliente, HttpPostedFileBase fupImagem)
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
                if (ClienteDAO.CadastrarCliente(cliente))
                {
                    ClienteDAO.CadastrarCliente(cliente);
                    return RedirectToAction("ClientesCadastrados");
                }
                ModelState.AddModelError("", "Já existe um cliente com este CPF!!");
                return View(cliente);
            }
            else
            {
                return View(cliente);
            }
        }
        
        [Authorize]
        public ActionResult AlterarCliente(int id)
        {
            return View(ClienteDAO.BuscarClientePorID(id));
        }

        [Authorize]
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

        [Authorize]
        public ActionResult DetalhesCliente(int id, string cpf)
        {
            ViewBag.Automoveis = AutomovelDAO.BuscarAutomoveisPorCPFCliente(cpf);
            return View(ClienteDAO.BuscarClientePorID(id));
        }

        public ActionResult RemoverCliente(int id)
        {
            ClienteDAO.RemoverCliente(id);
            return RedirectToAction("ClientesCadastrados", "Cliente");
        }

        public ActionResult Vagas()
        {
            return View(VagaDAO.RetornarVagas());
        }
    }
}