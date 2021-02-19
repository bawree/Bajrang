using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BajRang.Models
{
    public class polls
    {
        
            [Key]
            public int PollId { get; set; }
            public string Question { get; set; }
        public bool Active { get; set; } = true;
            public int Yes { get; set; } = 0;
        public int No { get; set; } = 0;

        public string Option1 { get; set; }
        public string Option2 { get; set; }



        
    }
}