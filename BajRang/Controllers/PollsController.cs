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
    public class PollsController : Controller
    {
        private PollContext db = new PollContext();
        // GET: Polls
        public ActionResult Index()
        {
            ViewBag.DisplayList = db.Polls.ToList();
            return View(db.Polls.ToList());
        }

        public JsonResult GetPolls()
        {

            var polls = db.Polls.ToList();
            return new JsonResult { Data = polls, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        // GET: Polls/Details/5
       /* public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll @poll = db.Polls.Find(id);
            if (@poll == null)
            {
                return HttpNotFound();
            }
            return View(@poll);
        }*/

        // GET: Polls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Polls/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "POllId,Question,Active,Yes,No")] Poll @poll)
        {
            if (ModelState.IsValid)
            {
                db.Polls.Add(@poll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poll);
        }

        //YES: To store yes

        public void Yes(int? id)
        {
            if (id == null)
            {
                return;
            }
            Poll @poll = db.Polls.Find(id);
            if (@poll == null)
            {
                return;
            }
            poll.Yes++;
        }

        // No : To store no

        public void No(int? id)
        {
            if (id == null)
            {
                return;
            }
            Poll @poll = db.Polls.Find(id);
            if (@poll == null)
            {
                return;
            }
            poll.No++;
        }
        // GET: Polls/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
        }

        // POST: Polls/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
               // if(collection[])

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Polls/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Polls/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
