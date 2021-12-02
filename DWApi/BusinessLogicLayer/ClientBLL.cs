using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntitiesLayer;

namespace BusinessLogicLayer
{
    public class ClientBLL
    {
        private ClientDAL clientDAL;
        public List<Client> GetClients()
        {
            clientDAL = new ClientDAL();
            return clientDAL.GetClients();
        }
    }
}
