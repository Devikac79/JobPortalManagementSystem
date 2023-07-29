using JobPortalManagementSystem.Models;
using JobPortalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortalManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminHomepage()
        {
            return View();
        }

        public ActionResult AdminLayoutpage()
        {
            return View();
        }

        public ActionResult GetJobPostDetails()
        {
            JobPostRepository jobPostRepository = new JobPostRepository();
            ModelState.Clear();
            return View(jobPostRepository.GetJobPostDetails());
        }
        /// <summary>
        /// Get method to view Creating  a record
        /// </summary>
        /// <returns></returns>
        public ActionResult AddJobPost()
        {
            return View();
        }
        /// <summary>
        /// Post method to assign created value to database
        /// </summary>
        /// <param name="signup"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddJobPost(JobPost jobPost)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    JobPostRepository jobPostRepository = new JobPostRepository();
                    if (jobPostRepository.AddJobPost(jobPost))
                    {
                        ViewBag.Message ="Job post added Successful";
                        return RedirectToAction("GetJobPostDetails"); // Redirect to login page after successful registration
                    }
                }
                return View(jobPost);
            }
            catch
            {
                return View();
            }
        }

    }
}
