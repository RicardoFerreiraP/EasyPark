using EasyPark.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EasyPark.DAL
{
    public class HistoricoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static Historico CarroEstacionado(Historico historico)
        {
            return ctx.Historicos.Include("Automovel").FirstOrDefault(x => x.Automovel.Placa.Equals(historico.Automovel.Placa) && x.DataSaida == null);
        }

        public static void OcuparVaga(Historico historico)
        {
            ctx.Historicos.Add(historico);
            ctx.SaveChanges();
        }

        public static Historico DetalhesVaga(int id)
        {
           return ctx.Historicos.Include("Automovel").Include("Vaga").FirstOrDefault(x => x.Vaga.VagaID == id);
        }

        public static Historico BuscarHistoricoPorVagaId(int id)
        {
            return ctx.Historicos.Include("Vaga").Include("Automovel").FirstOrDefault(x => x.Vaga.VagaID == id && x.DataSaida == null);
        }

        public static void Finalizar(Historico historico)
        {
            ctx.Entry(historico).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static Historico HistoricoNome(int id)
        {
            return ctx.Historicos.Include("Automovel").FirstOrDefault(y => y.Automovel.Cliente.ClienteID == id);
        }

        public static List<Historico> BuscarHistorico(int id)
        {
            return ctx.Historicos.Include("Automovel.Cliente").Where(x => x.Automovel.Cliente.ClienteID == id).ToList();
        }
    }
}