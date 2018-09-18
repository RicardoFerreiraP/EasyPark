using EasyPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPark.DAL
{
    public class VagaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<Vaga> RetornarVagas()
        {
            return ctx.Vagas.ToList();
        }

        public static void CadastrarVaga(Vaga vaga)
        {
            ctx.Vagas.Add(vaga);
            ctx.SaveChanges();
        }
    }
}