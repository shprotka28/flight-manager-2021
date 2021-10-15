using System;
using System.ComponentModel.DataAnnotations;
using Data.Entity;

namespace flight_manager_2021.Models.Reservations
{
    public class ReservationsCreateViewModel
    {
        /// <summary>
        /// administrator and passenger can create reservation  
        /// </summary>

        //show the data by Flight
        public Flight FlightInformation;

        //checks if the field is empty
        [Required(ErrorMessage = "First name is required.")]
        //initiation data input by administrator and passenger for passenger's first name
        public string FirstName { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Second name is required.")]
        //initiation data input by administrator and passenger for passenger's second name
        public string SecondName { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Last name is required.")]
        //initiation data input by administrator and passenger for passenger's last name
        public string LastName { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter EGN")]
        //checks for valid egn
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Incorrect EGN")]

        //initiation data input by administrator and passenger for passenger's egn 
        public string EGN { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter phone number.")]
        //checks for valid phone number
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Incorrect phone number")]
        //initiation data input by administrator and passenger for passenger's phone number
        public string PhoneNumber { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter nationality.")]
        //initiation data input by administrator and passenger for passenger's nationality
        public string Nationality { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter type of ticket.")]
        //initiation data input by administrator and passenger for type of ticket
        public string TypeOfTicket { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter email.")]
        //checks for valid email
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Incorrect email")]
        //initiation data input by administrator and passenger for passenger's email
        public string Email { get; set; }

        //accesses the data by id
        [Required()]
        public int PlaneId;
    }
}
