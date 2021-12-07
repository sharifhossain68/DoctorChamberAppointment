using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.Entity
{
    public class Appointment
    
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }
            [Required]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string Time { get; set; }
           
        [Required]
        public int PatientId { get; set; }


        


    }
}