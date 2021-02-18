using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BajRang.Models
{
    public class Users
    {
        [Key]
        [Required(ErrorMessage = "Name Required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Contact Required")]
        [RegularExpression(@"^[0-9]",ErrorMessage ="Contact number is wrong")]
        public int Contact { get; set; }

        [Required(ErrorMessage = "Email Id Required")]
        [DisplayName("Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
    ErrorMessage = "Email Format is wrong")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PassWord Required")]
        [StringLength(20, MinimumLength = 7)]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "Description Required")]
        public string Descr { get; set; }

        public virtual List<OldUsers> OldUsers { get; set; }
         
    }
}