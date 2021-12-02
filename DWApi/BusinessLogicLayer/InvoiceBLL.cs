using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntitiesLayer;

namespace BusinessLogicLayer
{
    public class InvoiceBLL
    {
        private InvoiceDAL invoice;
        public InvoiceBLL()
        {
            this.invoice = new InvoiceDAL();
        }
                
        public List<Invoice> GetInvoices()
        {
            return invoice.GetInvoices();
        }
        public Invoice GetInvoiceById(int id)
        {
            return invoice.GetInvoiceById(id);
        }
        public void DeleteInvoice(int id)
        {
            invoice.DeleteInvoice(id);
        }

        public bool InsertInvoice(Invoice invoiceNew)
        {
            return invoice.InsertInvoice(invoiceNew);
        }
    }
}
