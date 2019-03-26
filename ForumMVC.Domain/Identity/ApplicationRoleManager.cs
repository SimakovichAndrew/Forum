using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ForumMVC.Domain.Entities;
//using Microsoft.AspNet.Identity.Owin;
using ForumMVC.Domain.Repositories;
//using Microsoft.Owin;

namespace ForumMVC.Domain.Identity
{
      //Это стандартные для ASP.NET Identity классы по управлению ролями и пользователями. По сути эти классы выполняют роль репозиториев.

        //public ApplicationRoleManager(RoleStore<ApplicationRole> store)
        //            : base(store)
        //{ }
        public class ApplicationRoleManager : RoleManager<ApplicationRole>
        {
            public ApplicationRoleManager(RoleStore</*Identity*/ApplicationRole> store)
                : base(store)
            { }
            //public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
            //                                        IOwinContext context)
            //{
            //    return new ApplicationRoleManager(new
            //            RoleStore<IdentityRole>(context.Get<EFDbContext>()));
            //}
        }

    
}
