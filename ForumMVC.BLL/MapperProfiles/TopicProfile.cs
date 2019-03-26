using AutoMapper;
using ForumMVC.BLL.DTO;
using ForumMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.BLL.MapperProfiles
{
    public class TopicProfile: Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic, TopicDTO>().ReverseMap();
        }
    }
}
