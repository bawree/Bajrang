using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BajRang.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email ID is required")]
        [Display(Name="Email ID")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email ID is not valid")]
        public string Email { get; set; }

        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Contact")]
        public string Contact { get; set; }
    }
}