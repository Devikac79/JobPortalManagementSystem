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
        public ActionResult GetDetails()
        {
            SignupRepository signupRepository = new SignupRepository();
            ModelState.Clear();
            return View(signupRepository.GetDetails());
        }
        /// <summary>
        /// Get method to view Creating  a record
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDetails()
        {
            return View();
        }
        /// <summary>
        /// Post method to assign created value to database
        /// </summary>
        /// <param name="signup"></param>
        /// <returns></returns>
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
                        ViewBag.Message = "User Details Added Successfully";
                    }
                }
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        /// Get method to view selected record details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditDetails(int? id)
        {
            SignupRepository signupRepository = new SignupRepository();
            return View();
        }
        /// <summary>
        /// Editing the record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="signup"></param>
        /// <returns></returns>
        public ActionResult EditDetails(int? id, Signup signup)
        {
            try
            {
                SignupRepository signupRepository = new SignupRepository();
                signupRepository.EditDetails(signup);
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        /// Deleting the record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="signup"></param>
        /// <returns></returns>
        public ActionResult DeleteDetails(int id, Signup signup)
        {
            try
            {
                SignupRepository signupRepository = new SignupRepository();
                if (signupRepository.DeleteDetails(id))
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
    }
}