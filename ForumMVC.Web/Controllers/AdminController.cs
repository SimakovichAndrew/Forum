using ForumMVC.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumMVC.Web.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
           // return View(UserManager.userDTO());
        }

        private UserService UserManager
        {
            get
            {
                return null;
            }
        }
    }

   
}