/*
using JobPortalManagementSystem.Repository;
using JobPortalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetDetails()
        {
            SignupRepository signupRepository = new SignupRepository();
            ModelState.Clear();
            return View(signupRepository.GetDetails());
        }

        public ActionResult AddDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDetails(Signup signup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SignupRepository signupRepository = new SignupRepository();
                    if (signupRepository.AddDetails(signup))
                    {
                        ViewBag.Message = "USer details added successfully";
                    }
                }
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult EditDetails(int? Id)
        {
            SignupRepository signupRepository = new SignupRepository();
            return View(signupRepository.GetDetails().Find(signup => signup.Id == Id));

        }

        [HttpPost]
        public ActionResult EditDetails(int? Id,Signup signup)
        {
            try
            {
                SignupRepository signupRepository = new SignupRepository();
                signupRepository.EditDetails(signup);
                return RedirectToAction("GEtDetails");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DeleteDetails(int Id,Signup signup)
        {
            try
            {
                SignupRepository signupRepository = new SignupRepository();
                if (signupRepository.DeleteDetails(Id))
                {
                    ViewBag.AlertMessage = "USer details deleted successfully";
                }
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }
        }


    }
}*/




using JobPortalManagementSystem.Models;
using JobPortalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Homepage()
        {

            return View();
        }
        public ActionResult HomeLayoutpage()
        {

            return View();
        }


        /// <summary>
        /// Control view record page
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSignupDetails()
        {
            SignupRepository signupRepository = new SignupRepository();
            ModelState.Clear();
            return View(signupRepository.GetSignupDetails());
        }
        /// <summary>
        /// Get method to view Creating  a record
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSignupDetails()
        {
            return View();
        }
        /// <summary>
        /// Post method to assign created value to database
        /// </summary>
        /// <param name="signup"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddSignupDetails(Signup signup)
        {
            try
            {

                if (ModelState.IsValid)
                {
                   SignupRepository signupRepository = new SignupRepository();
                    if (signupRepository.AddSignupDetails(signup))
                    {
                        ViewBag.Message = "User Registration Successful";
                        return RedirectToAction("Login"); // Redirect to login page after successful registration
                    }
                }
                return View(signup);
            }
            catch
            {
                return View();
            }
        }










        /// View the details of a selected signup record for editing.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult EditSignupDetails(int? Id)
        {
            SignupRepository signupRepository = new SignupRepository();
            return View(signupRepository.GetSignupDetails().Find(signup => signup.Id == Id));
        }

        /// <summary>
        /// Edit the signup record.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="signup"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditSignupDetails(int? Id, Signup signup)
        {
            try
            {
                SignupRepository signupRepository = new SignupRepository();
                signupRepository.EditSignupDetails(signup);
                return RedirectToAction("GetSignupDetails");
            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        /// Deleting the record
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="signup"></param>
        /// <returns></returns>
        public ActionResult DeleteSignupDetails(int Id, Signup signup)
        {
            try
            {
                SignupRepository signupRepository = new SignupRepository();
                if (signupRepository.DeleteSignupDetails(Id))
                {
                    ViewBag.AlertMessage("User details deleted successfully");
                }
                return RedirectToAction("GetSignupDetails");
            }
            catch
            {
                return View();
            }
        }






        // GET: Login
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(Signin signin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SignupRepository signupRepository = new SignupRepository();
                    bool isValidUser = signupRepository.ValidateUser(signin.Username, signin.Password);
                    if (isValidUser)
                    {
                        // User is authenticated, you can add code to set authentication cookies or session variables
                        ViewBag.Message = "Login successful";
                        return RedirectToAction("AdminHomepage", "Admin"); // Redirect to the home page after successful login
                    }
                    else
                    {
                        ViewBag.Message = "Invalid username or password";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        /// contact us page
        /// </summary>
        /// <returns></returns>

        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult About()
        {
            return View();
        }

    }
}