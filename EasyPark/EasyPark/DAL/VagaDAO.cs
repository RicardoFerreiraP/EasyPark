using EasyPark.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static Vaga BuscarVagaPorId(int id)
        {
            return ctx.Vagas.Find(id);
        }

        public static int BuscarVagaPorIdVaga(int id)
        {
            Vaga vaga = ctx.Vagas.Find(id);
            return vaga.VagaID;
        }

        public static void AlterarVaga(int id)
        {
            Vaga vaga = BuscarVagaPorId(id);
            vaga.Disponivel = false;
            ctx.Entry(vaga).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}