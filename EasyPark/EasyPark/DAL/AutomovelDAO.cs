using System;
using System.Collections.Generic;
using EasyPark.Models;
using System.Linq;
using System.Data.Entity;

namespace EasyPark.DAL
{
    public class AutomovelDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static Automovel BuscaAutomovelPorId(int id)
        {
            return ctx.Automovel.Find(id);
        }

        public static Automovel BuscaAutomovelPorPlaca(Automovel automovel)
        {
            return ctx.Automovel.FirstOrDefault(x => x.Placa.Equals(automovel.Placa));
        }

        public static bool CadastrarAutomovel(Automovel automovel)
        {
            if (BuscaAutomovelPorPlaca(automovel) == null)
            {
                ctx.Automovel.Add(automovel);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Automovel> ListarTodosAutomoveis()
        {
            return ctx.Automovel.ToList();
        }

        public static void AlterarAutomovel(Automovel automovel)
        {
            ctx.Entry(automovel).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void RemoverAutomovel(int id )
        {
            ctx.Automovel.Remove(BuscaAutomovelPorId(id));
            ctx.SaveChanges();
        }
    }
}