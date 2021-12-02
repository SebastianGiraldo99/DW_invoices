using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayer;
using System.Web.Http.Cors;

namespace DWApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InvoicesController : ApiController
    {
        private InvoiceBLL InvoiceBLL;
        public InvoicesController()
        {
            this.InvoiceBLL = new InvoiceBLL();
        }
        // GET: api/Invoices
        public IEnumerable<Invoice> Get()
        {
            return InvoiceBLL.GetInvoices();
        }

        // GET: api/Invoices/5
        public Invoice Get(int id)
        {
            return InvoiceBLL.GetInvoiceById(id); 
        }

        // POST: api/Invoices
        public bool Post([FromBody]Invoice invoice)
        {
            return InvoiceBLL.InsertInvoice(invoice);
        }

        // DELETE: api/Invoices/5
        public void Delete(int id)
        {
            InvoiceBLL.DeleteInvoice(id);
        }
    }
}
