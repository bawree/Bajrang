using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BajRang.Models
{
    public class Poll
    {
        [Key]
        public int PollId { get; set; }
        public string Question { get; set; }
        public bool Active { get; set; }
        public int Yes{ get; set; }
        public int No { get; set; }

    }
}