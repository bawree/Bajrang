using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BajRang.Models;
using System.Data.Entity;
namespace BajRang.Context
{
    public class PostContext: DbContext
    { 
       public PostContext(): base("Constr")
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}