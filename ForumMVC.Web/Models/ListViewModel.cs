using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebForum.Domain.Entities;

namespace WebForum.WebUI.Models
{
    public class ListViewModel
    {
        //private IEnumerable<Topic> _topics;

        public IEnumerable<Topic> GetTopics { get/* => _topics*/; set/* => _topics = value*/; }
        public string CurrentTopic { get; set; }
        public ICollection<Comment> GetComments { get; set; }
        public PagingInfo PagingInfo{ get; set; }
    }
}