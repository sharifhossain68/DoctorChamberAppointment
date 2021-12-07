using DoctorChamberAppointmentMangementSystem.Models.Entity;
using DoctorChamberAppointmentMangementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorChamberAppointmentMangementSystem.Controllers
{
    public class UserController : Controller
    {

        private readonly DoctorAppointmentDbContext _dbContext = new DoctorAppointmentDbContext();


        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel loginVM)
        {
          
            var isValidUser = _dbContext.Registers.Any(x => x.UserName == loginVM.UserName);
            if (isValidUser)
            {
                var userInfo = _dbContext.Registers.FirstOrDefault(y => y.UserName == loginVM.UserName && y.Password == loginVM.Password);
                if (userInfo != null)
                {
                    var rolename = _dbContext.Roles.FirstOrDefault(z => z.RoleId == userInfo.RoleId).RoleName;

                    ViewBag.RoleName = rolename;
                    Session["Role"] = rolename;
                    if (rolename == "Doctor")
                    {
                        return Redirect("~/Doctor/Welcome");
                    }
                    else if (rolename == "Admin")
                    {
                        return Redirect("~/Admin/Index");
                    }
                  

                }
                else
                {
                    // Password is wrong

                    ViewBag.Error = "Password is wrong";
                }
            }

            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        // GET: /User/
        public JsonResult GetCountries()
        {
            var country = _dbContext.Coutries.ToList();
            var modified = country.Select(c => new
            {

                CountryId = c.CountryId,
                CountryName = c.CountryName

            });

            return Json(modified, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRoles()
        {
            var role = _dbContext.Roles.ToList();
            var modified = role.Select(r => new
            {
                RoleId = r.RoleId,
                RoleName = r.RoleName

            });

            return Json(modified, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Registration(RegisterVM register)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                Register aRegister = new Register()
                {
                    UserName = register.UserName,
                    Email = register.Email,
                    Password = register.Password,
                    ConfirmPassword = register.ConfirmPassword,
                    CountryId = register.CountryId,
                    RoleId = register.RoleId
                };

                if (aRegister != null)
                {
                    _dbContext.Registers.Add(aRegister);
                    _dbContext.SaveChanges();
                    message = "Successfully Added";
                    ModelState.Clear();
                }
                else
                {
                    message = "Please fill the form field";
                }


            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginVM )
        {


            var isValidUser = _dbContext.Registers.Any(x => x.UserName == loginVM.UserName);
            if (isValidUser)
            {
                var userInfo = _dbContext.Registers.FirstOrDefault(y => y.UserName == loginVM.UserName && y.Password == loginVM.Password);
                if (userInfo != null)
                {
                    var rolename = _dbContext.Roles.FirstOrDefault(z => z.RoleId == userInfo.RoleId).RoleName;

                    ViewBag.RoleName = rolename;
                    Session["Role"] = rolename;
                    if (rolename == "Doctor")
                    {
                        return Redirect("~/Doctor/Index");
                    }
                    return RedirectToAction("Index", "Admin");

                 
                    //if(rolename=="Admin")
                    //{
                    //    return RedirectToAction("Index", "Admin");
                    //}
                    //else if(rolename=="Doctor")
                    //{
                    //    return RedirectToAction("Index", "Doctor");
                    //}
                   





                }
                else
                {
                    // Password is wrong
                    return Json("Pasword is wrong", JsonRequestBehavior.AllowGet);
                }
            }
          

            return Json("Input Invalid",JsonRequestBehavior.AllowGet);

        }

    }
}
