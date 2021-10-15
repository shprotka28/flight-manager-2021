using System;
using System.ComponentModel.DataAnnotations;

namespace flight_manager_2021.Models.Users
{
    public class UsersCreateViewModel
    {
        /// <summary>
        /// administator can create employee's profile
        /// </summary>

        //checks if the field is empty
        [Required(ErrorMessage = "Enter username.")]
        //initiation data input by administrator for username 
        public string UserName { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter password.")]
        //initiation data input by administrator for password 
        public string Password { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter employee's email.")]
        //checks for valid email
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Incorrect email")]
        //initiation data input by administrator for employee's email 
        public string Email { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter employee's first name.")]
        //initiation data input by administrator for employee's first name 
        public string FirstName { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enteremployee's lastname.")]
        //initiation data input by administrator for employee's last name 
        public string LastName { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter employee's egn.")]
        //checks for valid egn

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Incorrect EGN")]
        //initiation data input by administrator for employee's egn 
        public string EGN { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter employee's address.")]
        //initiation data input by administrator for employee's address
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter employee's phone number.")]
        //checks if the field is empty
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Incorrect phone number.")]
        //initiation data input by administrator for employee's phone number
        public string PhoneNumber { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter where the plane will take off.")]
        //initiation data input by administrator employee's role 
        public string Role { get; set; }
    }
}
