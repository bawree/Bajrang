using BajRang.Models;
using BajRang.Context;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BajRang.Controllers
{
    public class UsersController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User usr)
        {
            if (ModelState.IsValid)
            {
                
                db.Users.Add(usr);
                db.SaveChanges();
                Session["UserId"] = usr.UserId.ToString();
                Session["Username"] = usr.Username.ToString();
                Session["Contact"] = usr.Username.ToString();
                Session["Name"] = usr.Username.ToString();
                Session["Email"] = usr.Username.ToString();

                EventContext db1 = new EventContext();
                Session["NoE"] = db1.Events.ToList().Count;

                pollsContext db2 = new pollsContext();
                Session["NoP"] = db2.polls.ToList().Count;

                return RedirectToAction("Index", "Post", new { area = "" });
                //return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Some error occured!");
            }
            return View(usr);
        }
        public ActionResult Edit(int? id) //(int? id,String? str)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User @event = db.Users.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User users)
        {
            

                    var obj = db.Users.Where(u => u.Username.Equals(users.Username) && u.Password.Equals(users.Password)).FirstOrDefault();
                    if(obj!=null)
                    {
                        Session["UserId"] = obj.UserId.ToString();
                        Session["Username"] = obj.Username.ToString();
                        Session["Name"] = obj.Name.ToString();
                        Session["Contact"] = obj.Contact.ToString();
                        Session["Email"] = obj.Email.ToString();
                return RedirectToAction("Index", "Post", new { area = "" });
            }
                
            
            Messagebox("Incorrect credentials");
            return View(users);
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserId"]!=null)
            {
                return View(db.Users.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public void GetDataForLaout()
        {

        }
        public void Messagebox(string xMessage)
        {
            Response.Write("<script>alert('" + xMessage + "')</script>");
        }
    }
}