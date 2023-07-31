




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
                        return RedirectToAction("Signin"); // Redirect to login page after successful registration
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
                return RedirectToAction("GetDetails");
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
                    string role = signupRepository.GetUserRole(signin.username, signin.password);

                    if (role == "user")
                    {
                        return RedirectToAction("Homepage", "Home");
                       
                    }
                    else if (role == "admin")
                    {
                        return RedirectToAction("AdminHomepage", "Admin");
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
        public ActionResult GetContact()
        {
            ContactRepository contactRepository = new ContactRepository();
            ModelState.Clear();
            return View(contactRepository.GetContact());
        }
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactRepository signupRepository = new ContactRepository();
                    if (signupRepository.AddContact(contact))
                    {
                        ViewBag.Message = "User Details Added Successfully";

                    }
                }
                return RedirectToAction("Homepage");
            }
            catch
            {
                return View();
            }
        }


       


    }
}