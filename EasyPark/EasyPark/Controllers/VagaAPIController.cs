using EasyPark.DAL;
using EasyPark.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace EasyPark.Controllers
{
    [RoutePrefix("api/Vaga")]
    public class VagaAPIController : ApiController
    {
        [Route("VagasDisponiveis")]
        public List<Vaga> GetVagasDisponiveis()
        {
            return VagaDAO.VagasDisponiveis();
        }
    }
}
