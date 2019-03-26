using ForumMVC.BLL.DTO;
using ForumMVC.BLL.Interfaces;
using ForumMVC.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ForumMVC.Web.Controllers
{
    public class ChatController : Controller
    {
        private UserDTO CurrentUser
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>().FindByName(User.Identity.Name);

            }
        }

        IOrderService repository;
       private int SelectTopicId;
        private string topicname;

        public int PageCom = 4;
        public ChatController(IOrderService comentRepository)
        {
            this.repository = comentRepository;
           
        }

        public ActionResult SelectTopic(string topicname, int page = 1/*int topicid*/)
        {
            Session["topicname"] = topicname;
            //SelectTopicId = repository.GetTopicName(topicname).TopicId;

            ChatListViewModel model = new ChatListViewModel
            {
                GetComments = repository.GetComments()
                .Where(p => topicname == null || p.ComTopicId == SelectTopicId)
                .OrderBy(p => p.CommentId)
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = topicname == null ?
                 repository.GetComments().Count() :
                 repository.GetComments().Where(e => e.ComTopicName == topicname).Count()
                },
                CurrentTopicName = topicname
            };

            //ViewBag.SelectTopicName = repository.GetTopicName(topicname).TopicName;


            return RedirectToAction("Chat") ;
 }



        [Authorize]

        public ViewResult Chat(/*ChatListViewModel modelstringstring topicname, */int page = 1)
        {
            if (Session["topicname"] == null)
                Session["topicname"] = repository.GetTopics().First();
            string topicname = (string)Session["topicname"];
            SelectTopicId = repository.GetTopicName(topicname).TopicId;
           
            ChatListViewModel model = new ChatListViewModel
            {
                GetComments = repository.GetComments()
                .Where(p => topicname == null || p.ComTopicId == SelectTopicId)
                .OrderBy(p => p.CommentId)
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = topicname == null ?
                 repository.GetComments().Count() :
                 repository.GetComments().Where(e => e.ComTopicName == topicname).Count()
                },
                CurrentTopicName = topicname
            };

            ViewBag.SelectTopicName = repository.GetTopicName(topicname).TopicName;


            return View(model);
        }
        //_______________________________________________________________________________



        [HttpGet]
        public ActionResult _Send()
        {
            return View();
        }



    [HttpPost]
        public ActionResult _Send(ChatListViewModel com, string returnUrl, int page = 1)
        {
            string topicname = com.CurrentTopicName;
            SelectTopicId = repository.GetTopicName(topicname).TopicId;
            repository.CreateComment(com.Content, SelectTopicId, User.Identity.Name);
            ChatListViewModel model = new ChatListViewModel
            {
                TopicId = SelectTopicId,
                GetComments = repository.GetComments()
                .Where(p => topicname == null || p.ComTopicId == SelectTopicId)
                .OrderBy(p => p.CommentId)
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = topicname == null ?
                 repository.GetComments().Count() :
                 repository.GetComments().Where(e => e.ComTopicName == topicname).Count()
                },
                CurrentTopicName = topicname,
                Autor = User.Identity.Name
            };

            ViewBag.SelectTopicName = repository.GetTopicName(topicname).TopicName;

            // var coment = repository.GetComments();
            //return View(model);
             return RedirectToAction ("Chat", "Chat" );
        }
       
    }
}