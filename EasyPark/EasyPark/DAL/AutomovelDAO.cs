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
    }
}