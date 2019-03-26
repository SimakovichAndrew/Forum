using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebForum.Domain.Entities;

namespace WebForum.Domain.Concrete
{
    //Данный класс наследуется от класса IdentityDbContext и поэтому уже имеет свойства Users и Roles, позволяющие взаимодействовать с таблицами пользователей и ролей. Поэтому здесь мы добавляем только свойство для ClientProfile.
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("EFDbContext") //base(conectionString)
        {
        }
        static ApplicationContext()
        {
            //заполнение базы данных первоначальными данными при ее создании средствами Entity Framework. Это позволит автоматически создать пользователей и назначить им роли при первом развертывании приложения. Для этого необходимо использовать метод PerformInitialSetup класса IdentityDbInit, являющегося специфичным для Entity Framework и ASP.NET Identity.
          Database.SetInitializer<ApplicationContext>(new IdentityDbInit());
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }


        public class IdentityDbInit : DropCreateDatabaseIfModelChanges<ApplicationContext>
        {
            protected override void Seed(ApplicationContext context)
            {
                PerformInitialSetup(context);
                base.Seed(context);
            }
            public void PerformInitialSetup(ApplicationContext context)
            {
                // настройки конфигурации контекста будут указываться здесь
            }
        }

       // public DbSet<ClientProfile> ClientProfiles { get; set; }

    }
}
