using ForumMVC.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumMVC.Web.Models
{
    public class TopicsListViewModel
    {
        //private IEnumerable<Topic> _topics;

        public IEnumerable<TopicDTO> GetTopics { get/* => _topics*/; set/* => _topics = value*/; }
        //public PagingInfo PagingInfoTopic { get; set; }
        public string CurrentTopic { get; set; }
        public ICollection<CommentDTO> GetComments { get; set; }
    }
}