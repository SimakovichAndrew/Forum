using ForumMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Domain.Repositories
{
    public interface ITopicRepository
    {
        IQueryable<Topic> Topics { get; }
    }
}
