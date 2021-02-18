using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BajRang.Models;

namespace BajRang.Context
{
    public class UserContext:DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<OldUsers> OldUsers { get; set; }
    }
}