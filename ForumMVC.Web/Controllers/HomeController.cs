using AutoMapper;
using ForumMVC.BLL.DTO;
using ForumMVC.BLL.Interfaces;
using ForumMVC.Web.Models;
//using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {

            orderService = serv;
            int dateTime = DateTime.Now.Hour;
            switch (dateTime)
            {
                case 1: case 2: case 3: case 4: case 5: case 22: case 23:  ViewBag.Greeting = "Доброй ночи"; break;
                case 6: case 7: case 8: case 9: case 10: ViewBag.Greeting = "Доброе утро"; break;
                case 11: case 12: case 13: case 14: case 15: case 16: case 17: ViewBag.Greeting = "Добрый день"; break;
                case 18: case 19: case 20: case 21: ViewBag.Greeting = "Добрый вечер"; break;
            }
        }
        //private IOrderService Context
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Get<IOrderService>();
        //    }
        //}
        
        public ActionResult Index()
        {

            // string hello = "Привет";
            // string Hello()
            // {

            //     int dateTime = DateTime.Now.Hour;
            //     switch (dateTime)
            //     {
            //         case 1: case 2: case 3: case 4: case 5: case 22: case 23: hello = "Доброй ночи"; break;
            //         case 6: case 7: case 8: case 9: case 10: hello = "Доброе утро"; break;
            //         case 11: case 12: case 13: case 14: case 15: case 16: case 17: hello = "Доброй день"; break;
            //         case 18: case 19: case 20: case 21: hello = "Добрый вечер"; break;

            //     }
            //     return hello;
            // }

            //ViewModel viewhello =  new ViewModel(Hello());

           
            int dateTime = DateTime.Now.Hour;
            switch (dateTime)
            {
                case 1: case 2: case 3: case 4: case 5: case 22: case 23: ViewBag.Greeting = "Доброй ночи"; break;
                case 6: case 7: case 8: case 9: case 10: ViewBag.Greeting = "Доброе утро"; break;
                case 11: case 12: case 13: case 14: case 15: case 16: case 17: ViewBag.Greeting = "Доброй день"; break;
                case 18: case 19: case 20: case 21: ViewBag.Greeting = "Добрый вечер"; break;
            }




            IEnumerable<CommentDTO> commentDtos = orderService.GetComments();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
            var phones = mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentDtos);

            return View(phones);
            //if (Session["isLoginRepeat"] == null)
            //    Session["isLoginRepeat"] = false;
            //return View(Context.User.ToList());
           // return View();
        }

               public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}