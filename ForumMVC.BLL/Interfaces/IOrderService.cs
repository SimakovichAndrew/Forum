using ForumMVC.BLL.DTO;
using ForumMVC.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.BLL.Interfaces
{
    public interface IOrderService:IDisposable
    {

        //void CreateTopic(TopicDTO topicDto);
        void CreateComment(string content, int topicid /*string topicname*/, string name);

        void MakeTopic(TopicDTO topicDto);
        void MakeComment(CommentDTO comentDto);
        CommentDTO GetComment(int? id);
        TopicDTO GetTopic(int? id);
        TopicDTO GetTopicName(string topicname);
        IEnumerable<CommentDTO> GetComments();
        IEnumerable<TopicDTO> GetTopics();
        //void Dispose();
        //IEnumerable<RecordDT> GetRecords();

       // Task<OperationDetails> CreateUser(/*string email, string userName, string password,*/ UserDTO userDto);
       //// void CreateUser(UserDTO userDto);
       // Task<ClaimsIdentity> Authenticate(UserDTO userDto);
       // Task SetInitialData(UserDTO AdminDto, List<string> roles);

    }
}
