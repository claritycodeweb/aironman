using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

using AIronMan.Api.Filters;
using AIronMan.Services;

namespace AIronMan.Api.Controllers
{
    [AuthToken]
    public class SiteController : ApiController
    {
        private ISiteService siteSrv;

        public SiteController(ISiteService siteSrv)
        {
            this.siteSrv = siteSrv;
        }

        // GET api/site
        public async Task<IHttpActionResult> Get()
        {
            var sites = await siteSrv.Get();
            return Ok(sites);
        }

        // GET api/site/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/site
        public void Post([FromBody]string value)
        {
        }

        // PUT api/site/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/site/5
        public void Delete(int id)
        {
        }
    }
}
