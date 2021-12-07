using DoctorChamberAppointmentMangementSystem.Models.Entity;
using DoctorChamberAppointmentMangementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorChamberAppointmentMangementSystem.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private readonly DoctorAppointmentDbContext _dbContext = new DoctorAppointmentDbContext();
        public ActionResult Index(string roleName)
        {
            var a = ViewBag.RoleName;
          ViewBag.RoleName = Session["Role"].ToString();
             return View();
        }
       
        public ActionResult PatientList()
        {
           var patient= _dbContext.Patient.ToList();

           return View(patient);
        }

        public ActionResult DoctorList()
        {
            var doctor = _dbContext.Doctors.ToList();

            return View(doctor);
        }
        public ActionResult AppointmentList()
   {
          

            DateTime nowDate = Convert.ToDateTime(DateTime.Today.Date.ToShortDateString());
            int day = 1;

            List<AppointmentList> appoints=new List<AppointmentList>();
          for(int i=0;i<1;i++)
          {
              TimeList obj2 = new TimeList();
              nowDate = nowDate.AddDays(day);
              obj2.Year = DateTime.Now.Year.ToString();
              obj2.Day = nowDate.ToString("dddd");
              obj2.Date = nowDate.ToString("MMMM dd");
              DateTime date = Convert.ToDateTime(obj2.Date);
              var patient = _dbContext.Patient.ToList();
              var doctors = _dbContext.Doctors.ToList();
              var appoint = _dbContext.Appointments.Where(d => d.Date == date).ToList();

              List<Patient> patientList = patient;
              List<Doctor> doctorList = doctors;
                    appoints  = (from a in appoint
                                                join p in patientList on a.PatientId equals p.Id
                                                join d in doctorList on p.DoctorId equals d.DoctorId
                                                select new AppointmentList
                                                {
                                                    Id=a.AppointmentId,
                                                    PatientName = p.PatientName,
                                                    AppointmentSerialNo = p.AppointmentSerialNo,
                                                    Time = a.Time,
                                                    PhoneNumber = p.PhoneNumber,
                                                    DoctorName = d.Name,
                                                    DoctorLocation = d.ChamberOfLocation,
                                                    DoctorPhoneNo = d.PhoneNo

                                                }).ToList();
                        }
                
         
                

            
           
            return View(appoints.ToList());
        }
        [HttpPost]
         public ActionResult Delete(int id)
        {
           Appointment appointDetails= _dbContext.Appointments.Find(id);
           _dbContext.Appointments.Remove(appointDetails);
           _dbContext.SaveChanges();
           return RedirectToAction("AppointmentList");


        }


    }
}
