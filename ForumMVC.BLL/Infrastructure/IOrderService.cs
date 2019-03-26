using ForumMVC.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.BLL.Infrastructure
{
    public interface IOrderService
    {
        void MakeTopic(TopicDTO topicDto);
        void MakeComment(CommentDTO comentDto);
        CommentDTO GetComment(int? id);
        TopicDTO GetTopic(int? id);
        IEnumerable<CommentDTO> GetComments();
        IEnumerable<TopicDTO> GetTopics();
        void Dispose();
    }
}
