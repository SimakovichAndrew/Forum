using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumMVC.Domain.Interfaces
{
    public interface IRepository<T> where T :class

    {
        //Здесь используется интерфейс IQueryable<T>, который позволяет получить последовательность
        // объектов Product и не требует указаний на то, как и где хранятся данные или как следует их
        //извлекать.Класс, который использует интерфейс IProductRepository, может получить объекты
        //Product, не зная того, где они содержатся или каким образом будут ему поставлены
        //IQueryable<T> Products { get; }
      //  IEnumerable<IdentityUser> All { get; }
        /*IQueryable */
        IEnumerable<T> GetAll();
        T Get(int id);
        /*IQueryable*/
        T GetString(string topicname);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
       // void Add(string item);
        void Update(T item);
        void Delete(int id);
        //  object Select(Func<object, object> p);
    }
}
