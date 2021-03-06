﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using C_R_M.Models;

namespace C_R_M.Controllers
{
    [PermisoAttribute]
    public class EstadodeCuentasController : Controller
    {
        private CRMEntities db = new CRMEntities();

        // GET: EstadodeCuentas
        public ActionResult Index()
        {
            if (AccountController.Account.GetUser == null)
                return RedirectPermanent("Login/Index");
            var estadodeCuenta = db.EstadodeCuenta.Include(e => e.Empresa);
            return View(estadodeCuenta);
        }

        // GET: EstadodeCuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (AccountController.Account.GetUser == null)
                return RedirectPermanent("Login/Index");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadodeCuenta estadodeCuenta = db.EstadodeCuenta.Include(e => e.Empresa).First(es=>es.Id_Empresa == id.Value);
            if (estadodeCuenta == null)
            {
                return HttpNotFound();
            }
            return View(estadodeCuenta);
        }

        // GET: EstadodeCuentas/Create
        public ActionResult Create()
        {
            if (AccountController.Account.GetUser == null)
                return RedirectPermanent("Login/Index");
            ViewBag.Empresa = new SelectList(db.Empresa.Where(em => em.EstadodeCuenta == null), "Id_Empresa", "Nombre");
            return View();
        }

        // POST: EstadodeCuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Empresa,Credito_Disponible")] EstadodeCuenta estadodeCuenta)
        {
            if (AccountController.Account.GetUser == null)
                return RedirectPermanent("Login/Index");
            if (ModelState.IsValid)
            {
                db.EstadodeCuenta.Add(estadodeCuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empresa = new SelectList(db.Empresa, "Id_Empresa", "Nombre", estadodeCuenta.Empresa);
            return View(estadodeCuenta);
        }

        // GET: EstadodeCuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (AccountController.Account.GetUser == null)
                return RedirectPermanent("Login/Index");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadodeCuenta estadodeCuenta = db.EstadodeCuenta.Include(e => e.Empresa).First(es => es.Id_Empresa == id.Value);
            if (estadodeCuenta == null)
            {
                return HttpNotFound();
            }
            return View(estadodeCuenta);
        }

        // POST: EstadodeCuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Empresa,Credito_Disponible")] EstadodeCuenta estadodeCuenta)
        {
            if (AccountController.Account.GetUser == null)
                return RedirectPermanent("Login/Index");
            if (ModelState.IsValid)
            {
                db.Entry(estadodeCuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadodeCuenta);
        }

        // GET: EstadodeCuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (AccountController.Account.GetUser == null)
                return RedirectPermanent("Login/Index");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadodeCuenta estadodeCuenta = db.EstadodeCuenta.Include(e => e.Empresa).First(es => es.Id_Empresa == id.Value);
            if (estadodeCuenta == null)
            {
                return HttpNotFound();
            }
            return View(estadodeCuenta);
        }

        // POST: EstadodeCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (AccountController.Account.GetUser == null)
                return RedirectPermanent("Login/Index");
            EstadodeCuenta estadodeCuenta = db.EstadodeCuenta.Find(id);
            db.EstadodeCuenta.Remove(estadodeCuenta);
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
