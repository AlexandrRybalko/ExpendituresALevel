using AutoMapper;
using BL.BLModels;
using BL.Services;
using ExpendituresALevel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpendituresALevel.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<WebAutoMapperProfile>());
            _mapper = new Mapper(mapperConfig);
        }
        // GET: Transaction
        public ActionResult Transactions()
        {
            var blTransactions = _transactionService.GetTransactions();
            var transactions = _mapper.Map<IEnumerable<TransactionModel>>(blTransactions);

            return View("/Views/Transaction/Transactions.cshtml", transactions);
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        public ActionResult Create(TransactionModel model)
        {
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var tranasaction = _mapper.Map<TransactionBLModel>(model);
                _transactionService.Create(tranasaction);

                return Transactions();
            }

            return View();
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _transactionService.GetById(id);
            var transaction = _mapper.Map<TransactionModel>(model);
            return View(transaction);
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        public ActionResult Edit(TransactionModel transaction)
        {
            if (ModelState.IsValid)
            {
                var blCategory = _mapper.Map<TransactionBLModel>(transaction);
                _transactionService.Edit(blCategory);

                return Transactions();
            }

            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            _transactionService.DeleteById(id);

            return Transactions();
        }
    }
}
