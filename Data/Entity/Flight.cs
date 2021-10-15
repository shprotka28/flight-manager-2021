using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Flight
    {
        /// <summary>
        /// 
        /// </summary>
        /// 


        //primary key
        [Key]
        public int Id { get; set; }

        //required passengers's location from for database
        [Required]
        public string LocationFrom { get; set; }

        //required passengers's location to for database
        [Required]
        public string LocationTo { get; set; }

        //required passengers's going date for database
        [Required]
        public DateTime TakeOffTime { get; set; }

        //required passengers's return date for database
        [Required]
        public DateTime LandingTime { get; set; }

        //required plane's type for database
        [Required]
        public string TypeOfPlane { get; set; }

        //required pilot's name for database
        [Required]
        public string NameOfAviator { get; set; }

        //required plane's capacity of economy class for database
        [Required]
        public int CapacityOfEconomyClass { get; set; }

        //required plane's capacity of business class for database
        [Required]
        public int CountOfBusinessClass { get; set; }

        //required plane's count of economy class for database
        [Required]
        public int CountOfEconomyClass { get; set; }

        //required plane's count of business class for database
        [Required]
        public int CapacityOfBusinessClass { get; set; }
    }
}
