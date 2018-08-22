using EasyPark.Models;

namespace EasyPark.DAL
{
    public class SingletonContext
    {
        private static Context context;

        private SingletonContext() { }

        public static Context GetInstance()
        {
            if (context == null)
            {
                context = new Context();
            }
            return context;
        }
    }
}