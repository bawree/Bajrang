using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using BajRang.Context;
using BajRang.Models;

namespace BajRang.Controllers
{
    public class OldUsersController : Controller
    {
        // GET: OldUsers
        
        public ActionResult Index()
        {
            return View();
        }
    }
}