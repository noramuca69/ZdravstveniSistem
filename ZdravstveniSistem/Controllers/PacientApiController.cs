using System.Linq;
using System.Web.Http;
using ZdravstveniSistem.Data;
using ZdravstveniSistem.Models;

namespace ZdravstveniSistem.Controllers
{
    [RoutePrefix("api/pacienti")]
    public class PacientApiController : ApiController
    {
        private readonly ZdravstveniSistemContext db = new ZdravstveniSistemContext();

        // GET: api/pacienti
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllPacients()
        {
            var pacients = db.Pacients.Select(p => new
            {
                p.Id,
                p.Ime,
                p.Priimek,
                p.DatumRojstva,
                p.Spol,
                p.TelefonskaStevilka,
                p.Email,
                p.Naslov
            }).ToList();

            return Ok(pacients);
        }
    }
}