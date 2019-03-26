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
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateUser(/*string email, string userName, string password,*/ UserDTO userDto);

        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO AdminDto, List<string> roles);
        UserDTO FindByName(/*int? id*/string name);
    }

}
