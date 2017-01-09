using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Model;
using WebApplication1.DataAcces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DaysController : Controller
    {
        private FoodClubDB db = new FoodClubDB();

        // GET: Days
        public ActionResult Index()
        {
            //Brug af Ajax 
            if (Request.IsAjaxRequest())
            {
                return PartialView(db.Days.Include("Members").AsNoTracking().ToList());
            }
            return View(db.Days.Include("Members").AsNoTracking().ToList());
        }

        public ActionResult ViewPhoto(int id)
        {
            var photo = db.Days.Find(id).Picture;
            if (photo != null)
            {
                return File(photo, "image/jpeg");
            }
            return File("~/Content/Img/mad1.jpg", "image/jpeg");

        }

        // GET: Days/Details/5
        public ActionResult Details(int? id)
        {
            Day day=null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                day = db.Days.Include("Members").First(p => p.DayId == id);

            }
            catch
            {
                
            }
            if (day == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView(day);
            }
            return View(day);
        }

        // GET: Days/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Days/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "DayId,Menu,Time")] Day day, HttpPostedFileBase Picture)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Picture.ContentLength > 0)
                    {
                        using (BinaryReader reader = new BinaryReader(Picture.InputStream))
                        {
                            day.Picture = reader.ReadBytes((int)Picture.InputStream.Length);
                        }
                    }
                }
                catch
                {
                    return HttpNotFound();
                }

                //Add all
                var members = db.Members.AsEnumerable().ToList();
                day.Members = members;

                db.Days.Add(day);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(day);
        }

        // GET: Days/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = db.Days.Find(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        // POST: Days/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DayId,Menu,Time")] Day day)
        {
            if (ModelState.IsValid)
            {
                db.Entry(day).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(day);
        }

        [Authorize]
        public ActionResult Tilmeld(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = db.Days.Include("Members").First(p => p.DayId == id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TilmeldConfirm(int id)
        {
            Day day = db.Days.Include("Members").First(p=>p.DayId==id);
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            Member member =db.Members.Include("Days").First(m=>m.Name==user.UserName);
            if (day.Members.Contains(member))
                return RedirectToAction("Index");
            day.Members.Add(member);
            member.Days.Add(day);
            db.Entry(day).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AfmeldConfirm(int id)
        {
            Day day = db.Days.Include("Members").First(p => p.DayId == id);
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            Member member = db.Members.Include("Days").First(m => m.Name == user.UserName);
            if (!day.Members.Contains(member))
                return RedirectToAction("Index");
            day.Members.Remove(member);
            member.Days.Remove(day);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Days/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Day day = db.Days.Find(id);
            if (day == null)
            {
                return HttpNotFound();
            }
            return View(day);
        }

        // POST: Days/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Day day = db.Days.Find(id);
            db.Days.Remove(day);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Search(string searchString)
        {
            List<Day> results = null;
            if (!String.IsNullOrEmpty(searchString))
            {
                results =
                    new List<Day>(db.Days.Include("Members").AsParallel().Where(p => p.Menu.Contains(searchString)));
                ViewBag.Ret = searchString;
            }
            else
            {
                results = new List<Day>(db.Days.Include("Members").AsParallel());
            }
            
            return View(results.ToList());
            
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
