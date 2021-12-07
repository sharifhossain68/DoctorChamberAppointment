using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.ViewModel
{
    public class PatientVM
    {



        public int Id { get; set; }
         //[Required]
        public int DoctorId { get; set; }
        //[Required]

        [Display(Name = "Name")]
        public string PatientName { get; set; }

        //[Required]

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //[Required]

        public int Age { get; set; }

        //[Required]
        public string Gender { get; set; }

        //[Required]
        //[RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Enter valid email")]
        public string Email { get; set; }
        //[Required]

        //[Display(Name = "National ID")]
        public string NationalIdNo { get; set; }

        //[Required]

        //[Display(Name = " Serial No")]
        public string AppointmentSerialNo { get; set; }
        //[Required]

        //[Display(Name = "Doctor Name")]
        //public string DoctorName { get; set; }

        [Required]
        public string Address { get; set; }

        //[Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }
        public TimeSpan Time { get; set; }
        public List<DoctorVM>doctors{get;set;}
    }
}