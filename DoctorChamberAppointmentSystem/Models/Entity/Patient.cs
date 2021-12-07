using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.Entity
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        [Column(TypeName="varchar")]
        public string PatientName { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string PhoneNumber { get; set; }

        [Required]
        
        public int Age { get; set; }

        [Required]
        [StringLength(6)]
        [Column(TypeName = "varchar")]
        public string Gender { get; set; }

        [Required]
        [StringLength(150)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string NationalIdNo { get; set; }

        [Required]
        [StringLength(150)]
        [Column(TypeName = "varchar")]
        public string AppointmentSerialNo { get; set; }

        [Required]

        public int DoctorId { get; set; }


        [Required]
        [StringLength(350)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }

     
        [StringLength(5)]
        [Column(TypeName = "varchar")]
        public string BloodGroup { get; set; }


   

    }
}