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
    public class pollsController : Controller
    {
        private pollsContext db = new pollsContext();

        // GET: polls
        public ActionResult Index()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            ViewBag.DisplayList = db.polls.ToList();
            ViewBag.Color = new List<string>() { "#f3934c", "#a95a51", "#c1c1c3", "#2f3c51", "#f39342" };
            return View(db.polls.ToList());
            
        }
        [ChildActionOnly]
        public ActionResult GetTotal()
        {
            int x = db.polls.ToList().Count;
            ViewBag.tot = x;
            return PartialView("GetTotal");

            
        }

        [ChildActionOnly]
        public ActionResult GetLatest()
        {
            List<polls> x = db.polls.ToList();
            
            ViewBag.cnt = x.Count;
            if (x.Count > 0)
            {
                ViewBag.lat = x.Last();
            }
            return PartialView("GetLatest");
        }


        [ChildActionOnly]
        public ActionResult PollResult()
        {
            List<polls> x = db.polls.ToList();

            ViewBag.cnt = x.Count;
            if (x.Count > 0)
            {
                ViewBag.obj = x;
            }
            return PartialView("PollResult");
        }

        // GET: polls/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            polls polls = db.polls.Find(id);
            if (polls == null)
            {
                return HttpNotFound();
            }
            return View(polls);
        }

        // GET: polls/Create
        public ActionResult Create()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            return View();
        }

        // POST: polls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PollId,Question,Option1,Option2,Active,Yes,No")] polls polls)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            if (ModelState.IsValid)
            {
                db.polls.Add(polls);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(polls);
        }



        //To take Vote as Positive

        public ActionResult Positive(int id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");

            polls polls = db.polls.Find(id);
            if (polls == null)
            {
                return HttpNotFound();
            }
            //polls polls = db.polls.Find(id);
            polls.Yes += 1;
            if (ModelState.IsValid)
            {
                db.Entry(polls).State = EntityState.Modified;
                db.SaveChanges();
               
            }

            return RedirectToAction("Index");
        }


        public ActionResult Negative(int id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");

            polls polls = db.polls.Find(id);
            if (polls == null)
            {
                return HttpNotFound();
            }
            //polls polls = db.polls.Find(id);
            polls.No += 1;
            if (ModelState.IsValid)
            {
                db.Entry(polls).State = EntityState.Modified;
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }





        // GET: polls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            polls polls = db.polls.Find(id);
            if (polls == null)
            {
                return HttpNotFound();
            }
            return View(polls);
        }

        // POST: polls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PollId,Question,Option1,Option2,Active,Yes,No")] polls polls)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            if (ModelState.IsValid)
            {
                db.Entry(polls).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(polls);
        }

        // GET: polls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            polls polls = db.polls.Find(id);
            if (polls == null)
            {
                return HttpNotFound();
            }
            return View(polls);
        }

        // POST: polls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            polls polls = db.polls.Find(id);
            db.polls.Remove(polls);
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
