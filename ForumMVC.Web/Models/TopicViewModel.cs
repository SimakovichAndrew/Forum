using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumMVC.Web.Models
{
    public class TopicViewModel
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        // public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string TopicAdmin { get; set; }

        public List<CommentViewModel> Comment { get; set; }
    }
}