using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class InvoiceDAL
    {
        private DB_DWEntities DbContext;
        public InvoiceDAL()
        {
            this.DbContext = new DB_DWEntities();
        }

       public List<Invoice> GetInvoices()
        {
            var listInvoice =  new List<Invoice>();
            using (DbContext)
            {
                var invoices = DbContext.INVOICE.Include("DETAIL_INVOICE").Include("CLIENT").Include("SALLER").Where(i => i.enabled == true).ToList();
                foreach (var item in invoices)
                {
                    listInvoice.Add(new Invoice
                    {
                        IdInvoice = item.id_invoice,
                        Date = item.date,
                        Details = MapDetailsInvoice(item.DETAIL_INVOICE.ToList()),
                        Saller = new Saller
                        {
                            IdSaller = item.SALLER.id_saller,
                            FirtsName = item.SALLER.first_name,
                            LastName = item.SALLER.last_name,
                            Phone = item.SALLER.phone
                        },
                        Client = new Client
                        {
                            IdClient = item.CLIENT.id_client,
                            FirstName = item.CLIENT.first_name,
                            LastName = item.CLIENT.last_name,
                            Address = item.CLIENT.address,
                            DOB = item.CLIENT.dob,
                            Phone = item.CLIENT.phone
                        }

                    }) ;

                }
            }
            return listInvoice;
        }

        public bool InsertInvoice(Invoice invoiceNew)
        {
            using (DB_DWEntities DbContext = new DB_DWEntities())
            {
                var invoiceDB = new INVOICE
                {
                    id_client = invoiceNew.Client.IdClient,
                    id_saller = invoiceNew.Saller.IdSaller,
                    date = DateTime.Now,
                    enabled = true
                };
                DbContext.INVOICE.Add(invoiceDB);
                DbContext.SaveChanges();
                foreach (var item in invoiceNew.Details)
                {
                    DbContext.DETAIL_INVOICE.Add(new DETAIL_INVOICE
                    {
                        id_detail = item.IdDetail,
                        id_invoice = invoiceDB.id_invoice,
                        id_product = item.Product.IdProduct,
                        amount = item.Ammount
                    });
                    var product = DbContext.PRODUCT.Where(i => i.id_product == item.Product.IdProduct).FirstOrDefault();
                    product.stock-= item.Ammount;
                }
                DbContext.SaveChanges();

            }
            return true;
        }

        private List<DetailInvoice> MapDetailsInvoice(List<DETAIL_INVOICE> detailsInvoice)
        {
            var listDetailInvoices = new List<DetailInvoice>();
            foreach (var item in detailsInvoice)
            {
                listDetailInvoices.Add(new DetailInvoice
                {
                    IdDetail = item.id_detail,
                    Ammount = item.amount,
                    Product = new Product { IdProduct = item.PRODUCT.id_product,
                                           Name = item.PRODUCT.name,
                                           Price = item.PRODUCT.price,
                                           IdCategory = item.PRODUCT.id_category}
                });
            }
            return listDetailInvoices;
        }
        public Invoice GetInvoiceById(int id)
        {
            Invoice invoice = new Invoice();
            using (DB_DWEntities DbContext = new DB_DWEntities())
            {
                var item = DbContext.INVOICE.Include("DETAIL_INVOICE").Include("CLIENT").Include("SALLER").Where(i => i.id_invoice == id).FirstOrDefault();
                if(item == null)
                {
                    return invoice;
                }
                invoice = new Invoice
                {
                    IdInvoice = item.id_invoice,
                    Date = item.date,
                    Details = MapDetailsInvoice(item.DETAIL_INVOICE.ToList()),
                    Saller = new Saller
                    {
                        IdSaller = item.SALLER.id_saller,
                        FirtsName = item.SALLER.first_name,
                        LastName = item.SALLER.last_name,
                        Phone = item.SALLER.phone
                    },
                    Client = new Client
                    {
                        IdClient = item.CLIENT.id_client,
                        FirstName = item.CLIENT.first_name,
                        LastName = item.CLIENT.last_name,
                        Address = item.CLIENT.address,
                        DOB = item.CLIENT.dob,
                        Phone = item.CLIENT.phone
                    }

                };

            }
            return invoice;
        }
        public void DeleteInvoice(int id)
        {
            using(DB_DWEntities DbContext = new DB_DWEntities())
            {
                var item = DbContext.INVOICE.Where(i => i.id_invoice == id).FirstOrDefault();
                if(item == null)
                {
                    return;
                }
                item.enabled = false;
                DbContext.SaveChanges();
            }
        }
    }
}
