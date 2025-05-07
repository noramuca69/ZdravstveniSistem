using System.Linq;
using System.Web.Http;
using ZdravstveniSistem.Data;

namespace ZdravstveniSistem.Controllers
{
    [RoutePrefix("api/zdravniki")]
    public class ZdravnikApiController : ApiController
    {
        private readonly ZdravstveniSistemContext db = new ZdravstveniSistemContext();

        // GET: api/zdravniki
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllZdravniki()
        {
            var zdravniki = db.Zdravniks.Select(z => new
            {
                z.Id,
                z.Ime,
                z.Priimek,
                z.Specializacija,
                z.Email,
                z.TelefonskaStevilka,
                z.LetoZaposlitve
            }).ToList();

            return Ok(zdravniki);
        }
    }
}
