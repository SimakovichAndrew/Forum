using AutoMapper;
using ForumMVC.BLL.DTO;
using ForumMVC.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.BLL.MapperProfiles
{
    public class ClientProfile:Profile
    {
        public ClientProfile()
        {
            CreateMap<UserDTO, ApplicationUser>().ReverseMap();
        }
    }
}
