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
   public class EFCommentRepository :IRepository<Comment> // ICommentRepository
    {
        private EFDbContext db;

        public EFCommentRepository(EFDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments;
        }
       

        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }

        public Comment GetString(string commentcname)
        {
            throw new NotImplementedException();
        }

        public void Create(Comment com)
        {
            db.Comments.Add(com);
        }

        public void Update(Comment com)
        {
            db.Entry(com).State = EntityState.Modified;
        }

        public IEnumerable<Comment> Find(Func<Comment, Boolean> predicate)
        {
            return db.Comments.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Comment book = db.Comments.Find(id);
            if (book != null)
                db.Comments.Remove(book);
        }

       
    }
}
