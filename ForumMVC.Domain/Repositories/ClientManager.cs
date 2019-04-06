using ForumMVC.Domain.Entities;
using ForumMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Domain.Repositories
{
    public class ClientManager : IClientManager
    {
        public EFDbContext Database { get; set; }
        public ClientManager(EFDbContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }
        public ClientProfile Find(/*int? id*/string name)
        {
           return Database.ClientProfiles.Find(name);
            throw new NotImplementedException();
        }



        public void Dispose()
        {
            Database.Dispose();
        }

     
    }
}