using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight_manager_2021.Models.Users
{
    public class UsersViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EGN { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }
    }
}
