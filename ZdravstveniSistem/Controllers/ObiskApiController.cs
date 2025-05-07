using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZdravstveniSistem.Data;

namespace ZdravstveniSistem.Controllers
{
    [RoutePrefix("api/obiski")]
    public class ObiskApiController : ApiController
    {
        private readonly ZdravstveniSistemContext db = new ZdravstveniSistemContext();
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllObiski()
        {
            var obiski = db.Obisks.Select(o => new
            {
                o.Id,
                o.DatumObiska,
                o.RazlogObiska,
                o.Diagnoza,
                o.Opombe,
                Pacient = new
                {
                    o.Pacient.Id,
                    Ime = o.Pacient.Ime,
                    Priimek = o.Pacient.Priimek
                },
                Zdravnik = new
                {
                    o.Zdravnik.Id,
                    Ime = o.Zdravnik.Ime,
                    Priimek = o.Zdravnik.Priimek
                },
                Recepti = o.Recepti.Select(r => new
                {
                    r.Id,
                    r.ImeZdravila,
                    r.Doziranje,
                    r.DneviJemanja,
                    r.Navodila
                })
            }).ToList();

            return Ok(obiski);
        }
    }
}
