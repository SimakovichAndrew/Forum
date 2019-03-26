using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumMVC.Domain.Interfaces;
using ForumMVC.Domain.Entities;
using ForumMVC.Domain.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumMVC.Domain.Repositories
{
    public class EFClientRepository : IRepository<ClientProfile>
    {
        private EFDbContext dbClientContext = new EFDbContext();
        public IQueryable<ClientProfile> Products => dbClientContext.ClientProfiles;

        public EFClientRepository(EFDbContext context)
        {
            dbClientContext = context;
        }

        public void Create(ClientProfile item)
        {
            dbClientContext.ClientProfiles.Add(item);
        }

        public void Delete(int id)
        {
            ClientProfile client = dbClientContext.ClientProfiles.Find(id);
            if (client != null)
                dbClientContext.ClientProfiles.Remove(client);
        }

        public IEnumerable<ClientProfile> Find(Func<ClientProfile, bool> predicate)
        {
            return dbClientContext.ClientProfiles.Where(predicate).ToList();
        }

        public ClientProfile Get(int id)
        {
            return dbClientContext.ClientProfiles.Find(id);
        }

        public IEnumerable<ClientProfile> GetAll()
        {
            return dbClientContext.ClientProfiles;
        }

        public void Update(ClientProfile item)
        {
            dbClientContext.Entry(item).State = EntityState.Modified;
        }

       // IQueryable<ClientProfile> IRepository<ClientProfile>.All => dbClientContext.ClientProfiles;// throw new NotImplementedException();

        public IEnumerable<ClientProfile> All => dbClientContext.ClientProfiles;

        IEnumerable<IdentityUser> IRepository<ClientProfile>.All => throw new NotImplementedException();

        //throw new NotImplementedException();

        ClientProfile IRepository<ClientProfile>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IQueryable<ClientProfile> IRepository<ClientProfile>.GetAll()
        {
            return dbClientContext.ClientProfiles; //throw new NotImplementedException();
        }

        IQueryable<ClientProfile> IRepository<ClientProfile>.Find(Func<ClientProfile, bool> predicate)
        {
            return dbClientContext.ClientProfiles.Where(predicate).AsQueryable<ClientProfile>();// throw new NotImplementedException();
        }

        //public IEnumerable<ClientProfile> Find(Func<ClientProfile, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Create(ClientProfile item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(ClientProfile item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
