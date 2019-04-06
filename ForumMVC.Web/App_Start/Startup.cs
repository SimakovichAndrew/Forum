using ForumMVC.BLL.Interfaces;
using ForumMVC.BLL.Service;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(ForumMVC.Web.App_Start.Startup))]

namespace ForumMVC.Web.App_Start
{
    public class Startup
    {
        private IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);

            // регистрация менеджера ролей
           // app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("EFDbContext");
        }
    }
    //___________________________________________________________________________
    ///*IUserService*/IOrderService userService;
    //public Startup()
    //{
    //    this.userService = (/*UserService*/IOrderService)DependencyResolver.Current.GetService(typeof(OrderService/*UserService*/));
    //}
    //public void Configuration(IAppBuilder app)
    //{

    //    // настраиваем контекст
    //    app.CreatePerOwinContext</*IUserService*/IOrderService>(CreateUserService);

    //    //устанавливаем аутентификацию на основе куки
    //    app.UseCookieAuthentication(new CookieAuthenticationOptions
    //    {
    //        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
    //        LoginPath = new PathString("/Account/Register"),//неавторизованные пользователи направляются сюда
    //    });
    //}

    //private IOrderService CreateUserService()
    //{
    //    return userService;
    //}


    //________________________________________________________________________________________________________________________

}
    