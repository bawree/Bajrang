using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BajRang.Models;
using System.ComponentModel.DataAnnotations;

namespace BajRang.Context
{
    public class PollContext:DbContext
    {
        public PollContext() : base("Constr") { }
        public virtual DbSet<Poll> Polls { get; set; }
    }
}