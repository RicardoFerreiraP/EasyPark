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
            return ctx.Automoveis.Find(id);
        }

        public static Automovel BuscaAutomovelPorPlaca(Automovel automovel)
        {
            return ctx.Automoveis.FirstOrDefault(x => x.Placa.Equals(automovel.Placa));
        }

        public static bool CadastrarAutomovel(Automovel automovel)
        {
            if (BuscaAutomovelPorPlaca(automovel) == null)
            {
                ctx.Automoveis.Add(automovel);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Automovel> ListarTodosAutomoveis()
        {
            return ctx.Automoveis.Include("Cliente").ToList();
        }

        public static void RemoverAutomovel(int id )
        {
            ctx.Automoveis.Remove(BuscaAutomovelPorId(id));
            ctx.SaveChanges();
        }
        public static List<Automovel> BuscarAutomoveisPorCPFCliente(string cpf)
        {
            return ctx.Automoveis.Include("Cliente").Where(x => x.Cliente.CPF.Equals(cpf)).ToList();
        }
    }
}