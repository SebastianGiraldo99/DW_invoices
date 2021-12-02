using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class SellerDAL
    {
        public List<Saller> GetSallers()
        {
            var listSeller = new List<Saller>();
            using (DB_DWEntities ContextDB = new DB_DWEntities())
            {
                var sellers = ContextDB.SALLER.ToList();
                foreach (var item in sellers)
                {
                    listSeller.Add(new Saller
                    {
                        IdSaller = item.id_saller,
                        FirtsName = item.first_name,
                        LastName = item.last_name,
                        Phone = item.phone
                    }) ;
                }
                return listSeller;
            }
        }
    }
}
