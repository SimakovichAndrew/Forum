using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using ForumMVC.Domain.Entities;

namespace ForumMVC.Domain.Entities
{
    public class Topic
    {
        public int TopicId { get; set;}
        public string TopicName { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string TopicAdmin { get; set; }
       // public int CommentionID { get; set; }
       // public Comment Comment { get; set; }
       // public virtual IdentityUser User { get; set; }

        //свойство навигации
       // public virtual ApplicationUser ApplicationUser { get; set; }

       // public virtual ICollection<Comment> Coments{ get; set; }
    }
}
