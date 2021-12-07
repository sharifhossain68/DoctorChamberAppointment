using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.Entity
{
    public class Register
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]        
        [StringLength(100)]
        [Column(TypeName="varchar")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(150)]
        public string Email { get; set; }

   


        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [DataType(DataType.Password)]

        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        public int CountryId { get; set; }
        [Required]
        public int RoleId { get; set; }
     

        public int IsActive { get; set; }

    }
}