using JobPortalManagementSystem.Models;
using JobPortalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortalManagementSystem.Controllers
{
    public class RegistrationController : Controller
    {
        public SignupRepository repository;

        public RegistrationController()
        {
            repository = new SignupRepository();
        }

        public ActionResult Register()
        {
            var model = new UserRegistrationViewModel
            {
                Countries = new SelectList(repository.GetCountries(), "countryId", "countryName"),
                States = new SelectList(new List<State>(), "stateId", "stateName"),
                Cities = new SelectList(new List<City>(), "cityId", "cityName")
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(UserRegistrationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Signup = new Signup
                    {
                        //Id = model.Id,
                        firstName = model.firstName,
                        lastName = model.lastName,
                        dateOfBirth = model.dateOfBirth,
                        gender = model.gender,
                        email = model.email,
                        phone = model.phone,
                        address = model.address,
                        city = model.city,
                        state = model.state,
                        pincode = model.pincode,
                        country = model.country,
                        username = model.username,
                        password = model.password,
                        confirmPassword = model.confirmPassword,
                        countryId = model.SelectedcountryId,
                        stateId = model.SelectedstateId,
                        cityId = model.SelectedcityId
                    };

                    repository.AddSignupDetails(Signup);

                    return RedirectToAction("RegistrationSuccess");
                }

                model.Countries = new SelectList(repository.GetCountries(), "countryId", "countryName");
                model.States = new SelectList(repository.GetStatesByCountry(model.SelectedcountryId), "stateId", "stateName");
                model.Cities = new SelectList(repository.GetCitiesByState(model.SelectedstateId), "cityId", "cityName");

                return View(model);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately.
                // For example, you can show an error message to the user.
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View(model);
            }
        }

        public ActionResult GetStatesByCountry(int countryId)
        {
            try
            {
                var states = repository.GetStatesByCountry(countryId);
                return Json(states, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately.
                // For example, you can show an error message to the user.
                return Json(new { error = "An error occurred while fetching states." });
            }
        }

        public ActionResult GetCitiesByState(int stateId)
        {
            try
            {
                var cities = repository.GetCitiesByState(stateId);
                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately.
                // For example, you can show an error message to the user.
                return Json(new { error = "An error occurred while fetching cities." });
            }
        }
    }
}
