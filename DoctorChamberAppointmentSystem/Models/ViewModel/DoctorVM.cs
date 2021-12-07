using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.ViewModel
{
    public class DoctorVM
    {
        [Display(Name="Serial No.")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage="Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your gender")]

        public string Gender { get; set; }
                [Required(ErrorMessage = "Please enter your medical name")]
        public string MedicalName { get; set; }

        [Required(ErrorMessage = "Please enter your department")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Please enter your Institution,Degree Details")]
        public string InstitutionOfDegree { get; set; }

                [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Enter valid email")]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

     


        [Required(ErrorMessage = "Please enter your upload of file")]
        [Display(Name = "Profile Image")]
        public string PhotoPath { get; set; }
                public HttpPostedFileBase UploadOfFile { get; set; }

                [Required(ErrorMessage = "Please enter your desination")]
        public string Degination { get; set; }
                [Required(ErrorMessage = "Please enter your speciality")]
                public string Speciality { get; set; }
                [Required(ErrorMessage = "Please enter your mobile no")]
                [Display(Name = "Mobile No.")]
        public string MobileNo { get; set; }
                [Required(ErrorMessage = "Please enter your chamber of address")]
                [Display(Name = "Chamber Of Address")]
        public string  ChamberOfAddress { get; set; }
                [Required(ErrorMessage = "Please enter your fees")]
        public double Fees  { get; set; }
              
                [Required(ErrorMessage="Please enter your start time")]

                public string StartTime { get; set; }
                      [Required(ErrorMessage = "Please enter your end time")]

                public string EndTime { get; set; }


                [Required(ErrorMessage = "Required")]
                public string StartAmPm { get; set; }

                [Required(ErrorMessage = "Required")]
                public string EndAmPm { get; set; }

                [Required(ErrorMessage = "Please enter your BMDC Reg No.")]
        [Range(1,9100)]
           public string BMDCRegNo { get; set; }

                [Required(ErrorMessage = "Please enter your Professional Description")]
                public string Description { get; set; }
    }
}