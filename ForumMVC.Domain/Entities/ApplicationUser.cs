using ForumMVC.Domain.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Domain.Entities
{
    public class ApplicationUser :IdentityUser
    {

        public virtual ClientProfile ClientProfile { get; set; }
        //public ApplicationUserManager (IUserStore<IdentityUser> store)
        //    : base(store)
        //{
        //}
        //public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
        //                                            IOwinContext context)
        //{
        //    EFDbContext db = context.Get<EFDbContext>();
        //    ApplicationUserManager manager = new ApplicationUserManager(new UserStore<IdentityUser>(db));
        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 5,
        //        RequireUppercase = true
        //    };
        //    return manager;
        //}

    }
}
