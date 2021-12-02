using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class DetailInvoice
    {
        public int IdDetail { get; set; }
        public int? Ammount { get; set; }

        public Product Product { get; set; }
    }
}
