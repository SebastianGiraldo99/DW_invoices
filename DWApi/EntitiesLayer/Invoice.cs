using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Invoice
    {
        public int IdInvoice { get; set; }
        public DateTime? Date { get; set; }
        public List<DetailInvoice> Details { get; set; }
        public Client Client { get; set; }
        public Saller Saller { get; set; }
        
        public decimal? Total { get 
            { 
                if (Details.Count > 0)
                    return Details.Sum(x => x.Ammount * x.Product.Price);
                return 0;
            }
        }

    }
}
