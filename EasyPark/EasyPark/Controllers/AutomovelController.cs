﻿using EasyPark.DAL;
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
        public ActionResult AutomovelCadastrados()
        {
            return View(AutomovelDAO.ListarTodosAutomoveis());
        }

        public ActionResult CadastrarAutomovel()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarAutomovel(Automovel automovel, HttpPostedFileBase fupImagem)
        {

            if (ModelState.IsValid)
            {

                if (AutomovelDAO.CadastrarAutomovel(automovel))
                {
                    AutomovelDAO.CadastrarAutomovel(automovel);
                    return RedirectToAction("AutomovelCadastrados");
                }
                ModelState.AddModelError("", "Já existe um Automovel com esta Placa!!");
                return View(automovel);
            }
            else
            {
                return View(automovel);
            }
        }

        public ActionResult AlterarAutomovel(int id)
        {
            return View(AutomovelDAO.BuscaAutomovelPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarAutomovel(Automovel automovelAlterado)
        {
            Automovel automovelOriginal = AutomovelDAO.BuscaAutomovelPorId(automovelAlterado.AutomovelID);

            automovelOriginal.Placa = automovelAlterado.Placa;
            automovelOriginal.Marca = automovelAlterado.Marca;
            automovelOriginal.Modelo = automovelAlterado.Modelo;
            automovelOriginal.Tipo =   automovelAlterado.Tipo;

            if (ModelState.IsValid)
            {
                AutomovelDAO.AlterarAutomovel(automovelOriginal);
                return RedirectToAction("AutomovelCadastrados", "Automovel");

            }
            else
            {
                return View(automovelOriginal);
            }
        }
        public ActionResult RemoverAutomovel(int id)
        {
            AutomovelDAO.RemoverAutomovel(id);
            return RedirectToAction("AutomovelCadastrados", "Automovel");
        }
    }
}