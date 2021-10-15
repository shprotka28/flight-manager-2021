using System;
using System.ComponentModel.DataAnnotations;

namespace flight_manager_2021.Models.Flights
{
    public class FlightsCreateViewModel
    {
        /// <summary>
        /// administrator and employee can create flights         
        /// </summary>

        //checks if the field is empty
        [Required(ErrorMessage = "Enter where the plane will take off.")]
        //initiation data input by administrator for location 
        public string LocationFrom { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter where the plane will land from.")]
        //initiation data input by administrator for location
        public string LocationTo { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter when it will go.")]
        //initiation data input by administrator for time to go
        public DateTime Going { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter when it will arrive.")]
        //initiation data input by administrator for time to arrive 
        public DateTime Return { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter type of plane.")]
        //initiation data input by administrator for type of plane 
        public string TypeOfPlane { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter plane's id.")]
        //initiation data input by administrator for plane's id
        public int PlaneID { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Aviator's name is required.")]
        //initiation data input by administrator for aviator's name
        public string NameOfAviator { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter capacity of economy class.")]
        //initiation data input by administrator for capacity of economy
        public int CapacityOfEconomyClass { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter capacity of bussiness class.")]
        //initiation data input by administrator for capacity of bussiness
        public int CapacityOfBusinessClass { get; set; }
    }
}
