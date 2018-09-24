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

        [Authorize]
        public ActionResult FuncionariosCadastrados()
        {
            return View(FuncionarioDAO.ListarTodosFuncionarios());
        }

        [Authorize]
        public ActionResult CadastrarFuncionario()
        {
            return View();
        }

        [Authorize]
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
                    return RedirectToAction("FuncionariosCadastrados", "Funcionario");
                }
                ModelState.AddModelError("", "Já existe um funcionario com este CPF!!");
                return View(funcionario);
            }
            else
            {
                return View(funcionario);
            }
        }

        [Authorize]
        public ActionResult AlterarFuncionario(int id)
        {
            return View(FuncionarioDAO.BuscarFuncionarioPorID(id));
        }

        [Authorize]
        [HttpPost]
        public ActionResult AlterarFuncionario(Funcionario funcionarioAlterado)
        {
           Funcionario funcionarioOriginal = FuncionarioDAO.BuscarFuncionarioPorID(funcionarioAlterado.FuncionarioID);

            funcionarioOriginal.Nome     = funcionarioAlterado.Nome;
            funcionarioOriginal.CPF      = funcionarioAlterado.CPF;
            funcionarioOriginal.Telefone = funcionarioAlterado.Telefone;
            funcionarioOriginal.Senha    = funcionarioAlterado.Senha;
            

            if (ModelState.IsValid)
            {
                FuncionarioDAO.AlterarFuncionario(funcionarioOriginal);
                return RedirectToAction("FuncionariosCadastrados", "Funcionario");

            }
            else
            {
                return View(funcionarioOriginal);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "CPF, Senha")] Funcionario funcionario)
        {
           Funcionario funcionarioCAD = FuncionarioDAO.BuscarFuncionarioLogin(funcionario);
            if (funcionarioCAD != null || funcionario.CPF.Equals("admin") && funcionario.Senha.Equals("admin"))
            {
                //autenticar
                FormsAuthentication.SetAuthCookie(funcionario.CPF, false);
                return RedirectToAction("MostrarVagas", "Historico");
            }
            ModelState.AddModelError("", "CPF ou senha inválidos");
            return View(funcionario);
        }

        public ActionResult RemoverFuncionario(int id)
        {
            FuncionarioDAO.RemoverFuncionario(id);
            return RedirectToAction("FuncionariosCadastrados", "Funcionario");
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Funcionario");
        }

        public ActionResult Empresa()
        {
            return View();
        }

    }
}