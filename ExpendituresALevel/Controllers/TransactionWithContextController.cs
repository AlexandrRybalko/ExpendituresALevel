using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExpendituresALevel.Models;

namespace ExpendituresALevel.Controllers
{
    public class TransactionWithContextController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        static List<TransactionModel> transactions;
        //service

        public TransactionWithContextController()
        {
            transactions = new List<TransactionModel>
            {
                new TransactionModel{ Id = 1, Title = "dsfasd", Description = "dsafsdf", CreatedDate = DateTime.Now},
                new TransactionModel{ Id = 2, Title = "dsfasd", Description = "dsafsdf", CreatedDate = DateTime.Now}
            };
        }

        // GET: TransactionWithContext
        public ActionResult Index()
        {
            return View(transactions);
        }

        // GET: TransactionWithContext/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionModel transactionModel = transactions.FirstOrDefault(x => x.Id == id);
            if (transactionModel == null)
            {
                return HttpNotFound();
            }
            return View(transactionModel);
        }

        // GET: TransactionWithContext/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionWithContext/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Value,Description,Title,CreatedDate,UpdatedDate")] TransactionModel transactionModel)
        {

            if (ModelState.IsValid)
            {
                transactions.Add(transactionModel);

                return View(transactionModel);
            }
            transactions.Add(transactionModel);
            return View(transactionModel);
        }

        // GET: TransactionWithContext/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionModel transactionModel = transactions.FirstOrDefault(x => x.Id == id);
            if (transactionModel == null)
            {
                return HttpNotFound();
            }
            return View(transactionModel);
        }

        // POST: TransactionWithContext/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value,Description,Title,CreatedDate,UpdatedDate")] TransactionModel transactionModel)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }
            return View(transactionModel);
        }

        // GET: TransactionWithContext/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionModel transactionModel = transactions.FirstOrDefault(x => x.Id == id);
            if (transactionModel == null)
            {
                return HttpNotFound();
            }
            return View(transactionModel);
        }

        // POST: TransactionWithContext/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transactions.RemoveAt(id);

            return RedirectToAction("Index");
        }
    }
}
