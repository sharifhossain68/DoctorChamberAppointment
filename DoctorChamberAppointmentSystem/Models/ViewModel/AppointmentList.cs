using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.ViewModel
{
    public class AppointmentList
    {
        public int Id { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Booked ID")]
        public string AppointmentSerialNo { get; set; }
        
        public string Time { get; set; }
        [Display(Name = "Patient Phone No.")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        [Display(Name = "Doctor Location")]
        public string DoctorLocation { get; set; }
        [Display(Name = "Doctor Phone No.")]
        public string DoctorPhoneNo { get; set; }
    }
}