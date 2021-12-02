using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class ClientDAL
    {
        public List<Client> GetClients()
        {
            var listClient = new List<Client>();

            using (DB_DWEntities ContextDB = new DB_DWEntities())
            {
                var clients = ContextDB.CLIENT.ToList();
                foreach (var item in clients)
                {
                    listClient.Add(new Client {IdClient = item.id_client,
                                               FirstName = item.first_name,
                                               LastName = item.last_name,
                                               Address = item.address,
                                               DOB = item.dob,
                                               Phone = item.phone});
                }
            }
            return listClient;

        }

    }
}
