using EasyPark.Models;
using System.Linq;

namespace EasyPark.DAL
{
    public class HistoricoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static Historico CarroEstacionado(Historico historico)
        {
            return ctx.Historicos.Include("Automovel").FirstOrDefault(x => x.Automovel.Placa.Equals(historico.Automovel.Placa));
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
    }
}