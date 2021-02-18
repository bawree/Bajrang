using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BajRang.Models;
using BajRang.Context;

namespace BajRang.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        UserContext db = new UserContext();
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    Users usr = new Users();
                    usr.Name = collection["Name"];
                    
                    usr.UserName = collection["UserName"];
                    usr.Contact = Convert.ToInt32(collection["Contact"]);
                    usr.Email = collection["Email"];
                    usr.PassWord = collection["PassWord"];
                    usr.Descr = collection["Descr"];
                    db.Users.Add(usr);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}