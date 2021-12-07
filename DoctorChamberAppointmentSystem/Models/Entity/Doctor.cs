using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.Entity
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }


        [Required]
        [StringLength(100)]
        [Column(TypeName="varchar")]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string Gender { get; set; }

        [Required]
        [StringLength(150)]
        [Column(TypeName = "varchar")]
        public string MedicalName { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "varchar")]
        public string InstitutionDegree { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Department { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "varchar")]
        public string UploadOfPhoto { get; set; }

        [Required]
        [StringLength(150)]
        [Column(TypeName = "varchar")]
        public string Speciality { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Degination { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string PhoneNo { get; set; }


        [Required]
        [StringLength(350)]
        [Column(TypeName = "varchar")]
        public string ChamberOfLocation { get; set; }

        [Required]
        public double Fees { get; set; }


        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]

        public string BMDCRegNo { get; set; }
                [Required]
                [StringLength(10)]
                [Column(TypeName = "varchar")]
               
        public string StartTime { get; set; }
                [Required]
                [StringLength(10)]
                [Column(TypeName = "varchar")]
               
        public string EndTime { get; set; }
       


       
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "varchar")]
        public string Description { get; set; }
    }
}