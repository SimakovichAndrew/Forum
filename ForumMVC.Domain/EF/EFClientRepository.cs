using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Domain.Abstract;
using WebForum.Domain.Entities;

namespace WebForum.Domain.Concrete
{
    public class EFClientRepository: IRepository<ClientProfile>
    {
        private EFDbContext dbClientContext = new EFDbContext();
        public IQueryable<ClientProfile> ClientProfiles => dbClientContext.clientProfiles;

        public EFClientRepository(EFDbContext context)
        {
            dbClientContext = context;
        }
      
        public void Create(ClientProfile item)
        {
            dbClientContext.clientProfiles.Add(item);
        }

        public void Delete(int id)
        {
            ClientProfile client = dbClientContext.clientProfiles.Find(id);
            if (client != null)
                dbClientContext.clientProfiles.Remove(client);
        }

        public IEnumerable<ClientProfile> Find(Func<ClientProfile, bool> predicate)
        {
            return dbClientContext.clientProfiles.Where(predicate).ToList();
        }

        public ClientProfile Get(int id)
        {
            return dbClientContext.clientProfiles.Find(id);
        }

        public IEnumerable<ClientProfile> GetAll()
        {
            return dbClientContext.clientProfiles;
        }

        public void Update(ClientProfile item)
        {
            dbClientContext.Entry(item).State = EntityState.Modified;
        }

        //IEnumerable<ClientProfile> IRepository<ClientProfile>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //ClientProfile IRepository<ClientProfile>.Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

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
