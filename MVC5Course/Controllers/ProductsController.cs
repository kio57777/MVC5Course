using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    //public class ProductsController : Controller
    {
      //  private FabricsEntities1 db = new FabricsEntities1();

        //這是用老師的IRepository.EF6.tt產生的
        //ProductRepository repo = new ProductRepository(); 

        // GET: Products
        public ActionResult Index()
        {
            //db.Product.ToList()
       //  var data = repo.All();
         var data = repo.All().Take(5);
            //var data = repo.Get超級複雜的資料集();
            return View(data);
            //return View(db.Product.Where(p=> !p.isDeleted).ToList());
        }
        [HttpPost]
        public ActionResult Index(IList<Products批次更新ViewModel> data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var product = repo.Find(item.ProductId);
                    product.Stock = item.Stock;
                    product.Price = item.Price;
                }

                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(repo.All().Take(5));
        }

        //   [HttpPost]
        //public ActionResult Index(Product[] products)// IList<Product> products
        // //public ActionResult Index(IList<Product> data)
        // {
        //     foreach (var item in products)
        //     {
        //         var product = repo.Find(item.ProductId);
        //         product.Stock = item.Stock;
        //         product.Price = item.Price;
        //     }
 
        //     repo.UnitOfWork.Commit();
 
        //     return RedirectToAction("Index");
        // }
 
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            //if (product == null)
            //{
            //    return HttpNotFound();
            //}

            Product product = repo.Find(id.Value);
            if (product == null && product.isDeleted)
            {
                return HttpNotFound();

            }
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            //ViewData["OrderLines"] = product.OrderLine.ToList();
            ViewBag.OrderLines = product.OrderLine.ToList();
            TempData["ProductsEditDoneMsg"] = "商品編輯成功";
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid) //判斷有無錯誤
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                //db.Product.Add(product);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          //  Product product = db.Product.Find(id);
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        //以下是ｍｖｃ內建的ｅｄｉｔ
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var db = (FabricsEntities1)repo.UnitOfWork.Context;
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}
        //以下是為延遲驗證的做法
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection form)
        {
            Product product = repo.Find(id);

            if (TryUpdateModel<Product>(product, new string[] {
                "ProductId","ProductName","Price","Active","Stock" }))
            {
                repo.UnitOfWork.Commit();

                TempData["ProductsEditDoneMsg"] = "商品編輯成功";

                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Product product = db.Product.Find(id);
            Product product = repo.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Product product = db.Product.Find(id);
            //db.Product.Remove(product);
            //db.SaveChanges();
            Product product = repo.Find(id);
            product.isDeleted = true;
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var db = (FabricsEntities1)repo.UnitOfWork.Context;
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
