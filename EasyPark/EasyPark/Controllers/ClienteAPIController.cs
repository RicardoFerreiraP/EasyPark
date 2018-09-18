using EasyPark.DAL;
using EasyPark.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace EasyPark.Controllers
{
    [RoutePrefix("api/Cliente")]
    public class ClienteAPIController : ApiController
    {
        [Route("Clientes")]
        public List<Cliente> GetClientes()
        {
            return ClienteDAO.ListarTodosClientes();
        }

    }
}
