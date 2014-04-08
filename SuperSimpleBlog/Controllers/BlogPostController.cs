using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperSimpleBlog.Models;
using System.Web.Security;
using WebMatrix.WebData;

namespace SuperSimpleBlog.Controllers
{
    public class BlogPostController : Controller
    {
        private BlogPostContext db = new BlogPostContext();

        //
        // GET: /BlogPost/

        public ActionResult Index()
        {
            return View(db.BlogPosts.ToList());
        }

        //
        // GET: /BlogPost/Details/5

        public ActionResult Details(int id = 0)
        {
            BlogPost blogpost = db.BlogPosts.Find(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }
            return View(blogpost);
        }

        //
        // GET: /BlogPost/Create
        [Authorize]
        public ActionResult Create()
        {
            BlogPost bp = new BlogPost();

            return View(bp);
            //return View();
        }

        //
        // POST: /BlogPost/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(BlogPost blogpost)
        {
            if (ModelState.IsValid)
            {

                UserProfile currentUser = db.UserProfiles.Find(WebSecurity.CurrentUserId);
                blogpost.User = currentUser;
                blogpost.PostDate = DateTime.Now;

                db.BlogPosts.Add(blogpost);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogpost);
        }

        //
        // GET: /BlogPost/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            BlogPost blogpost = db.BlogPosts.Find(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }
            return View(blogpost);
        }

        //
        // POST: /BlogPost/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogPost blogpost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogpost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogpost);
        }

        //
        // GET: /BlogPost/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BlogPost blogpost = db.BlogPosts.Find(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }
            return View(blogpost);
        }

        //
        // POST: /BlogPost/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogpost = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(blogpost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}