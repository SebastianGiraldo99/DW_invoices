using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntitiesLayer;

namespace BusinessLogicLayer
{
    public class SellerBLL
    {
        private SellerDAL seller;
        public List<Saller> GetSallers()
        {
            seller = new SellerDAL();
            return seller.GetSallers();
        }
    }
}
