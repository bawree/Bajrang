using BajRang.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BajRang.Controllers
{
    public class PostController : Controller
    {
        PostContext db = new PostContext();
        // GET: Post
        public ActionResult Index()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            List<Models.Post> list = db.Posts.ToList();
            ViewBag.Details = list;
            return View(list);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            Models.Post pt = db.Posts.Find(id);
            return View(pt);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Post post)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            if (ModelState.IsValid)
            {
                post.Username =(string) Session["Username"];
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            Models.Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
            Models.Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Users");
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
        public void LD(int id)
        {

        }
    }
}
