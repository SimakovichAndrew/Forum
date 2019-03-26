using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumMVC.Web.Models
{
    public abstract class ViewModelBase
    {
        public string Name { get; set; }
        public ViewModelBase(string name)
        {
            Name = name;
        }
    }

    public class ViewModel : ViewModelBase
    {
        public ViewModel(string name):base(name)
        {

        }
    }
}