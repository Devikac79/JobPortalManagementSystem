using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace JobPortalManagementSystem.Models
{
    public class Signup
    {
        public int Id { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please enter your first name.")]
        public string firstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Please enter your last name.")]
        public string lastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter your date of birth.")]
        public DateTime dateOfBirth { get; set; }

        [Display(Name = "Gender")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Gender must be a single character.")]
        [Required(ErrorMessage = "Please enter your gender.")]
        public char gender { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Required(ErrorMessage = "Please enter your email address.")]
        public string email { get; set; }

        [Display(Name = "Phone")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [Required(ErrorMessage = "Please enter your phone number.")]
        public string phone { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter your address.")]
        public string address { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Please enter your state.")]
        public string state { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter your city.")]
        public string city { get; set; }

        [Display(Name = "Pincode")]
        [Required(ErrorMessage = "Please enter your pincode.")]
        public int pincode { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please enter your country.")]
        public string country { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter your username.")]
        public string username { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password.")]
        public byte[] password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please confirm your password.")]
        public string confirmPassword { get; set; }
    }

}
