using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Homework9.Models
{
    public class AuthenticateModel
    {
        [Required(ErrorMessage = "No login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "No password")]
        public string Password { get; set; }
    }
}
