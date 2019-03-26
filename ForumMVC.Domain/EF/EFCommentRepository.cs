using ForumMVC.Domain.EF;
using ForumMVC.Domain.Entities;
using ForumMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace ForumMVC.Domain.Concrete
{
   public class EFCommentRepository : IRepository<Comment>//ICommentRepository
    {
        private EFDbContext dbCommentContext = new EFDbContext();
        public IQueryable<Comment> Comments => dbCommentContext.Comments;

        public IQueryable<Comment> Products => dbCommentContext.Comments;//throw new NotImplementedException();

        public IEnumerable<ClientProfile> All => dbCommentContext.ClientProfiles;//throw new NotImplementedException();

        public EFCommentRepository(EFDbContext context)
        {
            dbCommentContext = context;
        }
        public void Create(Comment item)
        {
            dbCommentContext.Comments.Add(item);
        }

        public void Delete(int id)
        {
            Comment comment = dbCommentContext.Comments.Find(id);
            if (comment != null)
                dbCommentContext.Comments.Remove(comment);
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            return dbCommentContext.Comments.Where(predicate).ToList();
        }

        public Comment Get(int id)
        {
            return dbCommentContext.Comments.Find(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return dbCommentContext.Comments;
        }

        public void Update(Comment item)
        {
            dbCommentContext.Entry(item).State = EntityState.Modified;
        }

        IQueryable<Comment> IRepository<Comment>.GetAll()
        {
            throw new NotImplementedException();
        }

        IQueryable<Comment> IRepository<Comment>.Find(Func<Comment, bool> predicate)
        {
            throw new NotImplementedException();
        }


        //public IQueryable<Comment> Comments
        //{
        //    get { return dbCommentContext.Comments; }
        //}
    }
}
