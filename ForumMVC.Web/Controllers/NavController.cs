using ForumMVC.BLL.Interfaces;
using ForumMVC.BLL.Service;
using ForumMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumMVC.Web.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        //public ActionResult Index()
        //{
        //    return View();
        //}
        IOrderService recordService;

        public NavController(IOrderService repo)
        {
            recordService = repo;
        }
        public PartialViewResult Menu(/*string topicname = null*/)
        {

            IEnumerable<string> topic = recordService.GetTopics()
             .Select(x => x.TopicName)
             .Distinct()
             .OrderBy(x => x);


            return PartialView(topic);
        }


        //public string Menu()
        //{
        //    return "Здесь будет меню";
        //}


        //// GET: Nav
        //public ActionResult Index()
        //{
        //    return View();
        //}


    }
}