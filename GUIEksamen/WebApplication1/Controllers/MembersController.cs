using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using WebApplication1.DataAcces;

namespace WebApplication1.Controllers
{
    public class MembersController : Controller
    {
        private FoodClubDB db = new FoodClubDB();

        // GET: Members
        public ActionResult Index()
        {
            //Brug af Ajax 
            if (Request.IsAjaxRequest())
            {
                return PartialView(db.Members.Include("Days").AsNoTracking().ToList());
            }

            return View(db.Members.Include("Days").AsNoTracking().ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Include("Days").First(m=>m.Id==id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

       // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
