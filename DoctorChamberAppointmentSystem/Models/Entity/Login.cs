using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.Entity
{
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }


        public int IsActive { get; set; }
    }
}