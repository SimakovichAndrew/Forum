using ForumMVC.Domain.EF;
using ForumMVC.Domain.Entities;
using ForumMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace ForumMVC.Domain.Concrete
{
   public class EFTopicRepository: IRepository<Topic> //ITopicRepository
    {
        private EFDbContext dbTopicContext = new EFDbContext();
        public IQueryable<Topic> Topics => dbTopicContext.Topics;

        public IQueryable<Topic> Products => dbTopicContext.Topics;//throw new NotImplementedException();

        public IEnumerable<ClientProfile> All => dbTopicContext.ClientProfiles;//throw new NotImplementedException();

        public EFTopicRepository (EFDbContext context)
        {
            dbTopicContext = context;
        }
        public void Create(Topic item)
        {
            dbTopicContext.Topics.Add(item);
        }

        public void Delete(int id)
        {
            Topic doctor = dbTopicContext.Topics.Find(id);
            if (doctor != null)
                dbTopicContext.Topics.Remove(doctor);
        }

        public IEnumerable<Topic> Find(Func<Topic, bool> predicate)
        {
            return dbTopicContext.Topics.Where(predicate).ToList();
        }

        public Topic Get(int id)
        {
            return dbTopicContext.Topics.Find(id);
        }

        public IEnumerable<Topic> GetAll()
        {
            return dbTopicContext.Topics;
        }

        public void Update(Topic item)
        {
            dbTopicContext.Entry(item).State = EntityState.Modified;
        }

        IQueryable<Topic> IRepository<Topic>.GetAll()
        {
            throw new NotImplementedException();
        }

        IQueryable<Topic> IRepository<Topic>.Find(Func<Topic, bool> predicate)
        {
            throw new NotImplementedException();
        }


        //public IQueryable<Topic> Topics
        //{
        //    get { return dbTopicContext.Topics; }
        //}
    }
}
