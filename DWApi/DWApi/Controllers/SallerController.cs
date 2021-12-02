using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessLogicLayer;
using EntitiesLayer;
namespace DWApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SallerController : ApiController
    {
        private SellerBLL seller;
        // GET: api/Saller
        public IEnumerable<Saller> Get()
        {
            seller = new SellerBLL();
            return seller.GetSallers();
        }

        // GET: api/Saller/5
        public string Get(int id)
        {
            return "Not implement";
        }

        // POST: api/Saller
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Saller/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Saller/5
        public void Delete(int id)
        {
        }
    }
}
