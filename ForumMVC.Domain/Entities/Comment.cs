using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumMVC.Domain.Entities;

namespace ForumMVC.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string ComAutor { get; set; }
        public string ComContent { get; set; }
        public DateTime ComTime { get; set; }
        public int ComTopicId { get; set; }
        public string ComTopicName { get; set; }

       public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
