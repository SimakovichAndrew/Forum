using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.BLL.DTO
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string ComAutor { get; set; }
        public string ComContent { get; set; }
        public DateTime ComTime { get; set; }
        public string ComTopicName { get; set; }
        public int ComTopicId { get; set; }
    }
}
