using AutoMapper;
using ForumMVC.BLL.DTO;
using ForumMVC.BLL.Interfaces;
using ForumMVC.BLL.MapperProfiles;
using ForumMVC.Domain.Repositories;
using ForumMVC.Domain.Entities;
using ForumMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ForumMVC.BLL.Infrastructure;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace ForumMVC.BLL.Service
{
    public class OrderService : IOrderService
    {

        IUnitOfWork Database { get; set; }

        public OrderService()
        {

        }
        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public CommentDTO GetComment(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Commenta"/*, ""*/);
            var com = Database.Comments.Get(id.Value);
            if (com == null)
                throw new ValidationException("Комментарий не найден"/*, ""*/);

            return new CommentDTO { ComAutor = com.ComAutor, CommentId = com.CommentId, ComContent = com.ComContent, ComTime = com.ComTime, ComTopicName=com.ComTopicName };
            //throw new NotImplementedException();
        }

        public IEnumerable<CommentDTO> GetComments()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(Database.Comments.GetAll());
           // var comps = Database.Comments.GetAll();
           // IEnumerable<CommentDTO> comentsDTO = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comps);//выполняет отображение коллекции объектов Doctor на коллекцию объектов DoctorDT
           // return comentsDTO;//throw new NotImplementedException();  //throw new NotImplementedException();
        }

        public TopicDTO GetTopic(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Topica"/*, ""*/);
            var com = Database.Topics.Get(id.Value);
            if (com == null)
                throw new ValidationException("Тopic не найден"/*, ""*/);

            return new TopicDTO { TopicAdmin = com.TopicAdmin, TopicName = com.TopicName, DateCreated = com.DateCreated, TopicId = com.TopicId };
            //throw new NotImplementedException();
        }
        public TopicDTO GetTopicName(string topicname)
        {
            if (topicname == null)
                return new TopicDTO {TopicName = "хоть что-нибудь."};
            //throw new ValidationException("Неизвестно имя Topica"/*, ""*/);
            var com = Database.Topics.GetString(topicname);
            if (com == null)
                throw new ValidationException("Тopic не найден"/*, ""*/);

            return new TopicDTO { TopicAdmin = com.TopicAdmin, TopicName = com.TopicName, DateCreated = com.DateCreated, TopicId = com.TopicId };
            //throw new NotImplementedException();
        }

        public IEnumerable<TopicDTO> GetTopics()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Topic, TopicDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Topic>, List<TopicDTO>>(Database.Topics.GetAll());
            //var tops = Database.Topics.GetAll();
            //IEnumerable<TopicDTO> topsDTO = Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicDTO>>(tops);//выполняет отображение коллекции объектов Doctor на коллекцию объектов DoctorDT
            //return topsDTO;
            // throw new NotImplementedException();
        }

        public void MakeComment(CommentDTO comentDto)
        {
            Topic topic = Database.Topics.Get(comentDto.ComTopicId);

            // валидация
            if (topic == null)
                throw new ValidationException("Топик не найден");
           
            Comment comm = new Comment
            {
                ComTime = DateTime.Now,
                ComAutor = /*"unknown"*/comentDto.ComAutor,
                ComTopicId = topic.TopicId,
                //TopicName = topic.TopicName,
                ComContent = comentDto.ComContent
            };
            Database.Comments.Create(comm);
            Database.Save();
            // Comment com = Database.Comments.Get(comentDto.CommentId); //throw new NotImplementedException();
        }

        public void CreateComment(string content, int topicid  /*string topicname*/, string name)
        {
            Comment comm = new Comment
            {
                //TopicName = topicname,
                ComTopicId = topicid,
                ComAutor = name,
                ComContent = content,
                ComTime = DateTime.Now

            };
            Database.Comments.Create(comm);
            Database.Save();
        }
        public void MakeTopic(TopicDTO topicDto)
        {
            Topic com = Database.Topics.Get(topicDto.TopicId);  //throw new NotImplementedException();
        }
        //_____________________________________________________________________________________________________
    
        //_____________________________________________________________________________________________________

        public void Dispose()
        {
            Database.Dispose(); //throw new NotImplementedException();
        }
    }
}
