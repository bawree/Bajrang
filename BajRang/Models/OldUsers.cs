using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BajRang.Models
{
    public class OldUsers
    {
        [Key]
        public string Email { get; set; }
        public string PassWord { get; set; }
        public virtual Users Users { get; set; }
    }
}