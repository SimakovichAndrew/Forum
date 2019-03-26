//using Microsoft.AspNet.Identity.EntityFramework;
using ForumMVC.Domain.Repositories;
using ForumMVC.Domain.Entities;
//using ForumMVC.Domain.Identity;
using ForumMVC.Domain.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using ForumMVC.Domain.Identity;

namespace ForumMVC.Domain.Repositories
{
    //Класс инкапсулирует все менеджеры для работы с сущностями в виде свойств и хранит общий контекст данных.
    public class EFUnitOfWork: IUnitOfWork
    {
       private EFDbContext db;

        //поля
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private ClientManager clientManager;
        private EFCommentRepository commentRepository;
        private EFTopicRepository topicRepository;
        //private EFClientRepository clientRepository;


        //конструктор
        public EFUnitOfWork(string connectionString)
        {
            db = new EFDbContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
            //clientRepository = new EFClientRepository(db);
            //commentRepository = new EFCommentRepository(db);
            //topicRepository = new EFTopicRepository();

        }

        public IRepository<Topic> Topics
        {
            get
            {
                if (topicRepository == null)
                    topicRepository = new EFTopicRepository(db);
                return topicRepository;//; null
            }
        }
        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new EFCommentRepository(db);
                return commentRepository;//null; 
            }
        }
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }
        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }       
        

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        
        //public EFClientRepository ClientRepository
        //{
        //    get { return clientRepository; }
        //}

        //public EFTopicRepository TopicRepository
        //{
        //    get { return topicRepository; }
        //}

        //public EFCommentRepository CommentRepository
        //{
        //    get { return commentRepository; }
        //}






        //public IRepository<ClientProfile> ClientProfiles
        //{
        //    get
        //    {
        //        if (clientRepository == null)
        //            clientRepository = new EFClientRepository(db);
        //        return clientRepository;
        //    }
        //}


    }
}
