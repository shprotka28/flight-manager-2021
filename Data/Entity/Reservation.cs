using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Reservation
    {
        /// <summary>
        /// 
        /// </summary>
        /// 

        //primary key
        [Key]
        public int Id { get; set; }

        //required passengers's first name for database
        [Required]
        public string FirstName { get; set; }

        //required passengers's second name for database
        [Required]
        public string SecondName { get; set; }

        //required passengers's last name for database
        [Required]
        public string LastName { get; set; }

        //required primary key passengers's egn for database 
        [Required]
        public string EGN { get; set; }

        //required passengers's phone number for database
        [Required]
        public string PhoneNumber { get; set; }

        //required passengers's nationality for database
        [Required]
        public string Nationality { get; set; }

        //required passengers's type of ticket for database
        [Required]
        public string TypeOfTicket { get; set; }

        //required passengers's email for database
        [Required]
        public string Email { get; set; }

        public int PlaneId { get; set; }

        public bool IsNotNull()
        {
            if (FirstName == null || SecondName == null || LastName == null || EGN == null || PhoneNumber == null || Nationality == null || TypeOfTicket == null || Email == null || Email == null || PlaneId == null)
            {
                return false;
            }

            return true;
        }
    }
}
