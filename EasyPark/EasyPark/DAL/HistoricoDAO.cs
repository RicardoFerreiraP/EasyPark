using EasyPark.Models;

namespace EasyPark.DAL
{
    public class HistoricoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void OcuparVaga(Historico historico)
        {
            ctx.Historicos.Add(historico);
            ctx.SaveChanges();
        }
    }
}