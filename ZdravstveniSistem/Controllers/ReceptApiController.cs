using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZdravstveniSistem.Data;

namespace ZdravstveniSistem.Controllers
{
    [RoutePrefix("api/recept")]
    public class ReceptApiController : ApiController
    {
        private readonly ZdravstveniSistemContext db = new ZdravstveniSistemContext();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllRecepti()
        {
            var recepti = db.Recepts.Select(r => new
            {
                r.Id,
                r.ImeZdravila,
                r.Doziranje,
                r.DneviJemanja,
                r.Navodila,
                Obisk = new
                {
                    r.Obisk.Id,
                    r.Obisk.DatumObiska,
                    r.Obisk.RazlogObiska
                }
            }).ToList();

            return Ok(recepti);
        }
    }
}
