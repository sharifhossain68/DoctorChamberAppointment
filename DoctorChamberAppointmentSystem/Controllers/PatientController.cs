using DoctorChamberAppointmentMangementSystem.Models.Entity;
using DoctorChamberAppointmentMangementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorChamberAppointmentMangementSystem.Controllers
{
    public class PatientController : Controller
    {

        private readonly DoctorAppointmentDbContext _dbContext = new DoctorAppointmentDbContext();
        //
        // GET: /Patient/


        public ActionResult Department()
        {
            ViewBag.RoleName = "Patient";

            List<DepartmentVM> department = new List<DepartmentVM>()
            {
                new DepartmentVM{Id=1,Name="Cardiology"},
                new DepartmentVM{Id=2,Name="Dental"},
                new DepartmentVM{Id=3,Name="Dermatology"},
                new DepartmentVM{Id=4,Name="Gastroenterology"},
                new DepartmentVM{Id=5,Name="Medicine"},
                new DepartmentVM{Id=6,Name="Orthopaedics"}
            };

            return View(department.ToList());
        }

        public ActionResult DoctorList(string name)
        {
            var doctorDetailsList = _dbContext.Doctors.Where(dept => dept.Department == name).ToList();


            return View(doctorDetailsList);
        }
        [ActionName("DoctorProfile")]
        public ActionResult DoctorProfile(int id)
        {
            DateTime nowDate = Convert.ToDateTime(DateTime.Today.Date.ToShortDateString());
            int day = 1;
            List<TimeList> listOfDate = new List<TimeList>();
            for (int j = 0; j < 7; j++)
            {
                TimeList obj2 = new TimeList();
                nowDate = nowDate.AddDays(day);
                obj2.Year = DateTime.Now.Year.ToString();
                obj2.Day = nowDate.ToString("dddd");
                obj2.Date = nowDate.ToString("MMMM dd");
                obj2.DayDateYear = obj2.Day + " " + obj2.Date + " " + obj2.Year;
                listOfDate.Add(obj2);

            }
            List<TimeList> timeList = new List<TimeList>();
            var doctor = _dbContext.Doctors.SingleOrDefault(d => d.DoctorId == id);
            string start_Time = Convert.ToString(doctor.StartTime);
            string end_Time = Convert.ToString(doctor.EndTime);
            DateTime strTime = Convert.ToDateTime(start_Time);
            DateTime endTime = Convert.ToDateTime(end_Time);
            int minutes = 30;
            TimeSpan timeInterval = endTime.Subtract(strTime);
            int totalMinutes = Convert.ToInt32(timeInterval.TotalMinutes);
            int no_of_time_slot = totalMinutes / minutes;
            for (int i = 0; i < no_of_time_slot; i++)
            {
                TimeList obj = new TimeList();

                strTime = strTime.AddMinutes(minutes);
                obj.StartTime = strTime.ToString("hh:mm tt");
                timeList.Add(obj);
            }
            ViewBag.Time = timeList;
            ViewBag.DateDays = listOfDate;
             return View(doctor);

        }
        [HttpPost]
        [ActionName("DoctorProfile")]
        public ActionResult DoctorProfile(int id, string date,string time)
        {

            return RedirectToAction("Index", new {id=id,date=date,time=time });
            
        }



        public ActionResult Index(int id, string date, string time)
        {
            AppointmentVM appointment = new AppointmentVM();
            appointment.AppointmentDate = date;
            appointment.Time = time;
            Session["appointment"]=appointment;
          var doctor=_dbContext.Doctors.SingleOrDefault(d => d.DoctorId == id);
          DoctorVM aDoctor = new DoctorVM();
          aDoctor.DoctorId = id;
          Session["DoctorId"] = aDoctor;
            string serial=doctor.Name+" "+date+" "+time;
          PatientVM aPatient = new PatientVM();
          Session["Serial"] = serial;

            return View();
        }
        [HttpPost]
        public ActionResult Index(PatientVM aPatient)
        {
            DoctorVM aDoctor = (DoctorVM)Session["DoctorId"];
            aPatient.DoctorId = aDoctor.DoctorId;
          
            Patient patient = new Patient()
            {
                PatientName = aPatient.PatientName,
                Age = aPatient.Age,
                Address = aPatient.Address,
                Gender = aPatient.Gender,
                PhoneNumber = aPatient.PhoneNumber,
                BloodGroup = aPatient.BloodGroup,
                NationalIdNo = aPatient.NationalIdNo,
                AppointmentSerialNo = aPatient.AppointmentSerialNo,
                Email = aPatient.Email,
                DoctorId = aPatient.DoctorId
            };


            if (patient != null)
            {
                _dbContext.Patient.Add(patient);
                ViewBag.Success = "Appointment Successfully";
                ModelState.Clear();
                _dbContext.SaveChanges();
            }
           AppointmentVM appointment= (AppointmentVM)Session["appointment"];
           appointment.PatientId = patient.Id;
           PatientVM patientDoctorId =(PatientVM)Session["doctor"];
    
           Appointment aAppointment = new Appointment()
           {
               PatientId = appointment.PatientId,
               Date = Convert.ToDateTime(appointment.AppointmentDate),
               Time =appointment.Time

           };
           _dbContext.Appointments.Add(aAppointment);

           _dbContext.SaveChanges();
     
           
         int id=patient.DoctorId;
         int patientId = patient.Id;
         int appointmentId = aAppointment.AppointmentId;

         return RedirectToAction("BookedDetails", new { id = id,patientId=patientId,appointmentId=appointmentId });
         //return View();
            

            
        }
        public JsonResult GetBookedId()
        {

            var serial = Session["Serial"];



            var BookedSerialNo = new { serial = serial };

            return Json(BookedSerialNo, JsonRequestBehavior.AllowGet);
        }
        public ActionResult BookedDetails(int id, int patientId, int appointmentId)
       {
           ViewBag.Doctor= _dbContext.Doctors.SingleOrDefault(d => d.DoctorId == id);
           ViewBag.Patient = _dbContext.Patient.SingleOrDefault(p => p.Id == patientId);
           ViewBag.Appiont = _dbContext.Appointments.SingleOrDefault(d => d.AppointmentId == appointmentId);
         


          //var patient= _dbContext.Patient.SingleOrDefault(p => p.Id == patientId);
          return View();
        }
   
    }
}