using System.Collections;
using System.Collections.Generic;
using The_7.Models;

namespace The_7.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Blog> Blog { get; set; }
        public IEnumerable<Work> Work { get; set; }
        public IEnumerable<Team> Team { get; set; }
    }
}
