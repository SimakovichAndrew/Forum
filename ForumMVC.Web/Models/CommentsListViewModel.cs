using ForumMVC.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumMVC.Web.Models
{
    public class CommentsListViewModel
        {
        public IEnumerable<TopicDTO> GetTopics { get; set; }
        public IEnumerable<CommentDTO> GetComments { get; set; }
        //public PagingInfo PagingInfoCom { get; set; }
        public string CurrentTopicName { get; set; }
        public string Content;// { get ; set ; }
    }
    
}