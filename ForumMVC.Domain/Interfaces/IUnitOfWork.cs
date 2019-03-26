using ForumMVC.Domain.Entities;
using ForumMVC.Domain.Identity;
//using ForumMVC.Domain.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Domain.Interfaces
{
    //Объект UnitOfWork будет содержать ссылки на менеджеры пользователей и ролей, а также на репозиторий пользователей.
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IClientManager ClientManager { get; }
        IRepository<Topic> Topics { get; }
        IRepository<Comment> Comments { get; }
        // IRepository<IdentityUser> Client { get; }

        Task SaveAsync();
        void Save();
    }
}
