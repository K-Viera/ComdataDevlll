using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComdataDevlll.Models;
using ComdataDevlll.Tools;
using Microsoft.AspNet.Identity;

namespace ComdataDevlll.Controllers
{
    public class CollaboratorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Collaborators
        public ActionResult Index()
        {
            string userID = User.Identity.GetUserId();
            var collaborators = db.Collaborators.Where(c=>c.AplicationUserId==userID).Include(c => c.User);
            return View(collaborators.ToList());
        }

        // GET: Collaborators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaborator collaborator = db.Collaborators.Find(id);
            if (collaborator == null)
            {
                return HttpNotFound();
            }
            return View(collaborator);
        }

        // GET: Collaborators/Create
        public ActionResult Create()
        {
            //ViewBag.AplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: Collaborators/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Identification,Name,LastName,Addres,Email,Phone,Salary,Area,entryDate,gender,AplicationUserId")] Collaborator collaborator)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collaborator.AplicationUserId = User.Identity.GetUserId();
                    db.Collaborators.Add(collaborator);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                //ViewBag.AplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", collaborator.AplicationUserId);
                return View(collaborator);
            }
            catch (Exception e) 
            {
                Elog.save(this, e);
                return View(collaborator);
            }

        }

        // GET: Collaborators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaborator collaborator = db.Collaborators.Find(id);
            if (collaborator == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", collaborator.AplicationUserId);
            return View(collaborator);
        }

        // POST: Collaborators/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Identification,Name,LastName,Addres,Email,Phone,Salary,Area,entryDate,gender,AplicationUserId")] Collaborator collaborator)
        {
            try {
                if (ModelState.IsValid)
                {
                    collaborator.AplicationUserId = User.Identity.GetUserId();
                    db.Entry(collaborator).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                //ViewBag.AplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", collaborator.AplicationUserId);
                return View(collaborator);
            } catch (Exception e) 
            {
                Elog.save(this, e);
                return View(collaborator);
            }

        }

        // GET: Collaborators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaborator collaborator = db.Collaborators.Find(id);
            if (collaborator == null)
            {
                return HttpNotFound();
            }
            return View(collaborator);
        }

        // POST: Collaborators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                Collaborator collaborator = db.Collaborators.Find(id);
                db.Collaborators.Remove(collaborator);
                db.SaveChanges();
                return RedirectToAction("Index");
            } catch(Exception e) {
                Elog.save(this, e);
                return RedirectToAction("Index");
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult ConsultarColaboradorPorIdentificación()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConsultarColaboradorPorIdentificación([Bind(Include = "Identification")] Collaborator Collaborator) {
            try {
                Collaborator newCollaborator = db.Collaborators.Where(c => c.Identification == Collaborator.Identification).FirstOrDefault();
                if (newCollaborator != null) 
                {
                    return View(newCollaborator);
                }
                return View(Collaborator);

            }
            catch (Exception e) {
                Elog.save(this, e);
                return View(Collaborator);
            }
            
        }
    }
}
