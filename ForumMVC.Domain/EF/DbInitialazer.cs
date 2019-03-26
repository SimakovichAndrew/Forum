using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ForumMVC.Domain.Entities;
//using ForumMVC.Domain.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using ForumMVC.Domain.Identity;

namespace ForumMVC.Domain.Repositories
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext db)
        {


            ////db.ClientProfiles.Add(new ClientProfile { Name = "Вася", Address = "vasya@mail.ru"});
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            // создаем  роли  lkz 
            var role1 = new ApplicationRole{ Name = "admin" };    
            var role2 = new ApplicationRole{ Name = "moderator" }; 
            var role3 = new ApplicationRole { Name = "user" };
            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
            // создаем администратора
            var admin = new ApplicationUser
            {
                Email = "admin@mail.ru",
                UserName = "Boss"
            };
            string password = "123456";
            var result = userManager.Create(admin, password);
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
                userManager.AddToRole(admin.Id, role3.Name);
            }
            // создаем модератора
            var moderator = new ApplicationUser
            {
                Email = "mmm@mail.ru",
                UserName = "Moderator"
            };
            password = "654321";
            result = userManager.Create(moderator, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(moderator.Id, role2.Name);
                userManager.AddToRole(moderator.Id, role3.Name);
            }
            //создаем простого пользователя васю
            var user = new ApplicationUser
            {
                Email = "vvv@mail.ru",
                UserName = "Vasja"
            };
            password = "111111";
            result = userManager.Create(user, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role3.Name);

            }


            db.Topics.AddRange(new List<Topic> {
            new Topic { TopicName = "Футбол", TopicAdmin = "Вася", Content = "Динамо рулит", DateCreated = DateTime.Now },
            new Topic { TopicName = "Рыбалка", TopicAdmin = "Петя", Content = "Пить будем?", DateCreated = DateTime.Now },
            new Topic { TopicName = "Домоводство", TopicAdmin = "Люся", Content = "Включи плитку?", DateCreated = DateTime.Now }
            });


            db.Comments.Add(new Comment
            {
                //ComTopicName = "Футбол",
                ComTopicId = 1,
                ComAutor = "Вася",
                ComContent = "Спартак чемпион",
                ComTime = DateTime.Now,
            });
            db.Comments.Add(new Comment
            {
               // ComTopicName = "Домоводство",
                ComTopicId = 3,
                ComAutor = "Маша",
                ComContent = "Как пожарить сало",
                ComTime = DateTime.Now

            });

            db.Comments.Add(new Comment
            {
                //ComTopicName = "Рыбалка",
                ComTopicId = 2,
                ComAutor = "Коля",
                ComContent = "Сколько брать?",
                ComTime = DateTime.Now

            });





            db.SaveChanges();
        }
    }
}
