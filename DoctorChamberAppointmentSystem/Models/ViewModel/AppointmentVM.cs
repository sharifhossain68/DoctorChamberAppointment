using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorChamberAppointmentMangementSystem.Models.ViewModel
{
    public class AppointmentVM
    {
        public int Id { get; set; }

        public string ChamberName { get; set; }
        public double Fees { get; set; }
        public string AppointmentDate { get; set; }
        public string Time { get; set; }
        public int PatientId { get; set; }
        public PatientVM Patients { get; set; }
        public DoctorVM Doctors { get; set; }
    }
}