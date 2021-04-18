using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework9.Entities
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Org { get; set; }
        public Dictionary<int[], bool> Vote { get; set; }
    }
}
