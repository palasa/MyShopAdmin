﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using IBLL;

namespace Admin.Controllers
{
    public class ProductColorController : Controller
    {
        private MyShopEntities db = new MyShopEntities();

        public IProductColorBLL productColorBLL { get; set; }

        // GET: ProductColor
        public ActionResult Index()
        {
            return View(db.ProductColor.ToList());
        }

        // GET: ProductColor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductColor productColor = db.ProductColor.Find(id);
            if (productColor == null)
            {
                return HttpNotFound();
                // return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(productColor);
        }

        // GET: ProductColor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductColor/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Red,Green,Blue")] ProductColor productColor)
        {
            if (ModelState.IsValid)
            {
                db.ProductColor.Add(productColor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productColor);
        }

        // GET: ProductColor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductColor productColor = db.ProductColor.Find(id);
            if (productColor == null)
            {
                return HttpNotFound();
            }
            return View(productColor);
        }

        // POST: ProductColor/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Red,Green,Blue")] ProductColor productColor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(productColor).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(productColor);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductColor productColor)
        {
            productColorBLL.Modify(productColor);
            return RedirectToAction("Index");
        }

        // GET: ProductColor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductColor productColor = db.ProductColor.Find(id);
            if (productColor == null)
            {
                return HttpNotFound();
            }
            return View(productColor);
        }

        // POST: ProductColor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductColor productColor = db.ProductColor.Find(id);
            db.ProductColor.Remove(productColor);
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
