using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntitiesLayer;

namespace BusinessLogicLayer
{  
    
    public class ProductBLL
    {
        private ProductDAL product;
        public List<Product> GetProducts()
        {
            product = new ProductDAL();
            return product.GetProducts();
        }
    }
}
