using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BajRang.Models;

namespace BajRang.Context
{
    public class EventContext:DbContext
    {
        public EventContext() : base("Constr")
        {

        }
        public virtual DbSet<Event> Events { get; set; }
    }
}