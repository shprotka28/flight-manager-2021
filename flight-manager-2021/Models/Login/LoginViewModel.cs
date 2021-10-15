using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace flight_manager_2021.Models.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You need to enter a username")]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You need to ender a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
