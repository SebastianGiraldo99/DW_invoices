using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
namespace DataAccessLayer
{
    public class ProductDAL
    {
        public List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            using (DB_DWEntities ContextDB = new DB_DWEntities())
            {
                var products = ContextDB.PRODUCT.ToList();
                foreach (var item in products)
                {
                    listProducts.Add(new Product
                    {
                        IdProduct = item.id_product,
                        IdCategory = item.id_category,
                        Name = item.name,
                        Price = item.price,
                        Stock = item.stock
                    });
                }
                return listProducts;
            }
        }
    }
}
