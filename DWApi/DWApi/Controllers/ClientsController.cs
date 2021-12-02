using BusinessLogicLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DWApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientsController : ApiController
    {
        private ClientBLL ClientBLL;
        // GET: api/Clients
        public IEnumerable<Client> Get()
        {
            ClientBLL = new ClientBLL();
            return ClientBLL.GetClients();
        }

        // GET: api/Clients/5
        public string Get(int id)
        {
            return "Not implemented";
        }

        // POST: api/Clients
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clients/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clients/5
        public void Delete(int id)
        {
        }
    }
}
