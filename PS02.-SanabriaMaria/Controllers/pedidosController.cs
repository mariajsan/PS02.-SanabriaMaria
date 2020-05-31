using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.DataHandler.Encoder;
using PS02._SanabriaMaria.Models;

namespace PS02._SanabriaMaria.Controllers
{
    [Authorize]
    public class pedidosController : Controller
    {
        private pedidosdbcontext db = new pedidosdbcontext();

        // GET: pedidos
        public ActionResult Index()
        {
            var pedtop = db.Pedidos.ToList();
            var toppedidos = new List<pedidos>();

            foreach (var item in pedtop)
                if (item.Quantity >= 10) {
                    toppedidos.Add(item);
                }

            ViewBag.Top = toppedidos;
            var pedidos = db.Pedidos.Include(p => p.productos);
            return View(pedidos.ToList());
        }

        // GET: pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // GET: pedidos/Create
        public ActionResult Create()
        {
            ViewBag.IdProducto = new SelectList(db.productos, "Id", "Name");
            return View();
        }

        // POST: pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Client,GeneratedDate,Note,Status,IdProducto")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProducto = new SelectList(db.productos, "Id", "Name", pedidos.IdProducto);
            return View(pedidos);
        }

        // GET: pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProducto = new SelectList(db.productos, "Id", "Name", pedidos.IdProducto);
            return View(pedidos);
        }

        // POST: pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Client,GeneratedDate,Note,Status,IdProducto")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProducto = new SelectList(db.productos, "Id", "Name", pedidos.IdProducto);
            return View(pedidos);
        }

        // GET: pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // POST: pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pedidos pedidos = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedidos);
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
