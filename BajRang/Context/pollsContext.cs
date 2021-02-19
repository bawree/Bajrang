using BajRang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BajRang.Context
{
    public class pollsContext:DbContext
    { 
        public pollsContext() : base("Constr") { }
        public virtual DbSet<polls> polls { get; set; }
    }
}