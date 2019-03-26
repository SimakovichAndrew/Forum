using Microsoft.AspNet.Identity;
using ForumMVC.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using ForumMVC.Domain.Concrete;
using ForumMVC.Domain.Repositories;

namespace ForumMVC.Domain.Identity
{
    //Данный класс будет управлять пользователями: добавлять их в базу данных и аутентифицировать.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }

        //      public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        //      {
        //          EFDbContext db = context.Get<EFDbContext>();
        //          ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        //          return manager;
        //      }
    }

        //public class ApplicationUserManager : UserManager<IdentityUser>
        //{
        //    public ApplicationUserManager(IUserStore<IdentityUser> store)
        //        : base(store)
        //    {
        //    }
        //    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
        //                                                IOwinContext context)
        //    {
        //        EFDbContext db = context.Get<EFDbContext>();
        //        ApplicationUserManager manager = new ApplicationUserManager(new UserStore<IdentityUser>(db));
        //        manager.PasswordValidator = new PasswordValidator
        //        {
        //            RequiredLength = 5,
        //            RequireUppercase = true
        //        };
        //        return manager;
        //    }
    }

