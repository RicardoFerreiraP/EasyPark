using EasyPark.DAL;
using EasyPark.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EasyPark.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CadastrarFuncionario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarFuncionario([Bind(Include ="FuncionarioID, Nome, CPF, Telefone, Senha, ConfirmacaoDaSenha")] Funcionario  funcionario, HttpPostedFileBase fupImagem)
        {

            if (ModelState.IsValid)
            {

                if (fupImagem != null)
                {
                    string nomeImagem = Path.GetFileName(fupImagem.FileName);
                    string caminho = Path.Combine(Server.MapPath("~/Images/"), nomeImagem);
                    fupImagem.SaveAs(caminho);
                    funcionario.Imagem = nomeImagem;
                }
                else
                {
                    funcionario.Imagem = "semimagem.jpg";
                }
                if(FuncionarioDAO.CadastrarFuncionario(funcionario))
                {
                    FuncionarioDAO.CadastrarFuncionario(funcionario);
                    return RedirectToAction("ClientesCadastrados", "Cliente");
                }
                ModelState.AddModelError("", "Já existe um funcionario com este CPF!!");
                return View(funcionario);
            }
            else
            {
                return View(funcionario);
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "CPF, Senha")] Funcionario funcionario)
        {
           funcionario = FuncionarioDAO.BuscarFuncionarioLogin(funcionario);
            if (funcionario != null)
            {
                //autenticar
                FormsAuthentication.SetAuthCookie(funcionario.CPF, false);
                return RedirectToAction("ClientesCadastrados", "Cliente");
            }
            ModelState.AddModelError("", "CPF ou senha inválidos");
            return View(funcionario);
        }

    }
}