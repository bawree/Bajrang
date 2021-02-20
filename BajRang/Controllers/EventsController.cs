using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BajRang.Context;
using BajRang.Models;

namespace BajRang.Controllers
{
    public class EventsController : Controller
    {
        private EventContext db = new EventContext();
        
        // GET: Events
        public ActionResult Index()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");

            ViewBag.DisplayList = db.Events.ToList();
            
            return View(db.Events.ToList());
        }
        [ChildActionOnly]
        public ActionResult GetTotal()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            int x = db.Events.ToList().Count;
            ViewBag.tot = x;
            return PartialView("GetTotal");
        }

        [ChildActionOnly]
        public ActionResult GetLatest()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            List<Event> x = db.Events.ToList();
            ViewBag.cnt = x.Count;
            if (x.Count > 0)
            {
                ViewBag.lat = x.Last();
            }
            
            return PartialView("GetLatest");
        }

        public JsonResult GetEvents()
        {
            

            var events = db.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            return View();
            //return PartialView("~/Views/Events/Create.chtml");
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,Subject,Description,Partcipant,Start,End,ThemeColor")] Event @event)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id) //(int? id,String? str)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
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
        public ActionResult Edit([Bind(Include = "EventID,Subject,Description,Partcipant,Start,End,ThemeColor")] Event @event)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
