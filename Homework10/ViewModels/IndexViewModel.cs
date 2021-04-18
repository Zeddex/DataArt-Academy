using System;
using System.Collections.Generic;
using System.Linq;
using Homework10.Models;

namespace Homework10.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}
