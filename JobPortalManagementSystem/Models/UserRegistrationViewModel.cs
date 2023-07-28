﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace JobPortalManagementSystem.Models
{
    public class UserRegistrationViewModel
    {
        public int Id { get; set; }
        [DisplayName("First name")]
        public string firstName { get; set; }
        [DisplayName("Last name")]
        public string lastName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter your date of birth.")]
        public DateTime dateOfBirth { get; set; }
        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [DisplayName("Phone")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Address")]
        public string address { get; set; }
        [Required(ErrorMessage = "Select the city")]
        [DisplayName("City")]
        public string city { get; set; }
        [Required(ErrorMessage = "Select the state")]
        [DisplayName("State")]
        public string state { get; set; }
        [Required(ErrorMessage = "Pincode is required")]
        [DisplayName("Pincode")]
        public int pincode { get; set; }
        [Required(ErrorMessage = "Select the country")]
        [DisplayName("Country")]
        public string country { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [DisplayName("Username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        public string password { get; set; }
        [Required(ErrorMessage = "Re-enter the password")]
        [DisplayName("Confirm password")]
        public string confirmPassword { get; set; }

        // Dropdown lists and selected IDs for Country, State, and City
        public SelectList Countries { get; set; }
        public int SelectedcountryId { get; set; }

        public SelectList States { get; set; }
        public int SelectedstateId { get; set; }

        public SelectList Cities { get; set; }
        public int SelectedcityId { get; set; }
    }

}