using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumMVC.Web.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string ComAutor { get; set; }
        public string ComContent { get; set; }
        public DateTime ComTime { get; set; }
        public string TopicName { get; set; }
        public int TopicId { get; set; }
    }
}