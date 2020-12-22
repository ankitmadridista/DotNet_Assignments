using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using CompareAttribute = System.Web.Mvc.CompareAttribute;

namespace SecWebApp.Models
{
    public class User
    {
        [Key]
        [DataType(DataType.Text, ErrorMessage = "The username inserted is invalid")]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [MinLength(3, ErrorMessage = "The {0} value cannot be less than {1} characters.")]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please Enter Username")]
        public string UserName{ get; set;}

        [DataType(DataType.Password, ErrorMessage = "The password inserted is invalid")]
        [StringLength(16, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [MinLength(6, ErrorMessage = "The {0} value cannot be less than {1} characters.")]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [CompareAttribute("Password", ErrorMessage = "Confirm Password does not match")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text, ErrorMessage = "The Full name inserted is invalid")]
        [StringLength(15, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [MinLength(3, ErrorMessage = "The {0} value cannot be less than {1} characters.")]
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please Enter Full Name")]
        public string FullName { get; set; }
        [EmailAddress(ErrorMessage = "The Email inserted is invalid")]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        public string EmailId { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Select City")]
        [Display(Name = "City")]
        public int CityId { get; set; }
        [Display(Name = "Remember Me")]
        public bool IsActive { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }

    }
}