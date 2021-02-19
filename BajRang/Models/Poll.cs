using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BajRang.Models
{
    public class Poll
    {
        public int PollId { get; set; }
        public string Question { get; set; }
        public bool Active { get; set; }

    }
}