using BajRang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BajRang.Context
{
    public class DataContext:DbContext
    {
        public DataContext():base("ConStr")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}