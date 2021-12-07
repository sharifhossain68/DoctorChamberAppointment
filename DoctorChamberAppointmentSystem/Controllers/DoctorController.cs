using DoctorChamberAppointmentMangementSystem.Models.Entity;
using DoctorChamberAppointmentMangementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorChamberAppointmentMangementSystem.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorAppointmentDbContext _dbContext = new DoctorAppointmentDbContext();

        public ActionResult Welcome(string roleName)
        {
            var a = ViewBag.RoleName;
            ViewBag.RoleName = Session["Role"].ToString();
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.RoleName = Session["Role"].ToString();
            return View();
        }
        [HttpPost]
        public ActionResult Index(DoctorVM aDoctor)
        {
            
            string fileName = Path.GetFileNameWithoutExtension( aDoctor.UploadOfFile.FileName);
            string extension = Path.GetExtension(aDoctor.UploadOfFile.FileName);
            if (fileName.Length> 96)
            {
               ViewBag.Message = "Please enter your photo";
            }
            else if (extension != ".jpeg" && extension != ".jpg" && extension != ".png" && extension != ".bmp")
            {
                ViewBag.Message = "Please Enter photo file Accepted by jpg,jpeg,png,bmp";
            }
            else if (aDoctor.UploadOfFile.ContentLength > 4000000)
            {
                ViewBag.Message = "maximum length ";
            }
            else
            {
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                aDoctor.PhotoPath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                aDoctor.UploadOfFile.SaveAs(fileName);
            }
         
            try
            {
             
                Doctor doctor = new Doctor()
                {
                    Name = aDoctor.Name,
                    Gender = aDoctor.Gender,
                    MedicalName  = aDoctor.MedicalName,
                    Department = aDoctor.Department,
                    Speciality = aDoctor.Speciality,
                    ChamberOfLocation = aDoctor.ChamberOfAddress,
                    UploadOfPhoto = aDoctor.PhotoPath,
                    PhoneNo = aDoctor.MobileNo,
                    Fees = aDoctor.Fees,
                    Email = aDoctor.Email,
                    BMDCRegNo=aDoctor.BMDCRegNo,
                     StartTime=Convert.ToString( aDoctor.StartTime)+""+aDoctor.StartAmPm,
                   EndTime= Convert.ToString(aDoctor.EndTime)+""+aDoctor.EndAmPm,
                    Description=aDoctor.Description,
                    InstitutionDegree=aDoctor.InstitutionOfDegree,
                    Degination=aDoctor.Degination



                };
                _dbContext.Doctors.Add(doctor);
                _dbContext.SaveChanges();
                ViewBag.Success = "Save Successfully";
                ModelState.Clear();
            }
            catch(Exception e)
            {
              ViewBag.Error=  e.Message;
            }
    

                
                

            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult AppointmentList()
        {


            DateTime nowDate = Convert.ToDateTime(DateTime.Today.Date.ToShortDateString());
            int day = 1;

            List<AppointmentList> appoints = new List<AppointmentList>();
            for (int i = 0; i < 1; i++)
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
                appoints = (from a in appoint
                            join p in patientList on a.PatientId equals p.Id
                            join d in doctorList on p.DoctorId equals d.DoctorId
                            select new AppointmentList
                            {
                                Id = a.AppointmentId,
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
            Appointment appointDetails = _dbContext.Appointments.Find(id);
            _dbContext.Appointments.Remove(appointDetails);
            _dbContext.SaveChanges();
            return RedirectToAction("AppointmentList");


        }

    }
}
