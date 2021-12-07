using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.ViewModel
{
    public class RegisterVM
    {
       
        public int Id { get; set; }
        public string UserName { get; set; }


        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int CountryId { get; set; }
        public int RoleId { get; set; }


    }
}