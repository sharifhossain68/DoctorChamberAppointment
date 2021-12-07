using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.ViewModel
{
    public class LoginViewModel
    {
        public int Id { get; set; }

         [Required(ErrorMessage = "Please enter your name")]
        
        public string UserName { get; set; }
         [Required(ErrorMessage="Please enter your password")]
        public string Password { get; set; }
    }
}