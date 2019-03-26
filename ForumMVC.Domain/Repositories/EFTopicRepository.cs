using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumMVC.Domain.Interfaces;
using ForumMVC.Domain.Entities;

namespace ForumMVC.Domain.Repositories
{
   public class EFTopicRepository: IRepository<Topic>// ITopicRepository
    {
        private EFDbContext db;

        public EFTopicRepository(EFDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Topic> GetAll()
        {
            return db.Topics/*.Include(o => o.TopicId)*/;
        }

        public Topic Get(int id)
        {
            return db.Topics.Find(id);
        }

        public Topic GetString(string topicname)
        { 
            return db.Topics.Where(x=>x.TopicName==topicname).First();
            //throw new NotImplementedException();
        }

        public void Create(Topic topic)
        {
            db.Topics.Add(topic);
        }

        public void Update(Topic topic)
        {
            db.Entry(topic).State = EntityState.Modified;
        }
        public IEnumerable<Topic> Find(Func<Topic, Boolean> predicate)
        {
            return db.Topics.Include(o => o.TopicId).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Topic topic = db.Topics.Find(id);
            if (topic != null)
                db.Topics.Remove(topic);
        }

       
    }
}
