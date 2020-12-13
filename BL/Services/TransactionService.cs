﻿using AutoMapper;
using BL.BLModels;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionBLModel>();
                cfg.CreateMap<Transaction, TransactionBLModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperConfig);
        }

        public void Create(TransactionBLModel model)
        {
            var transaction = _mapper.Map<Transaction>(model);
            _transactionRepository.Create(transaction);
        }

        public void DeleteById(int id)
        {
            _transactionRepository.DeleteById(id);
        }

        public TransactionBLModel GetById(int id)
        {
            var transaction = _transactionRepository.GetById(id);

            return _mapper.Map<TransactionBLModel>(transaction);
        }

        public IEnumerable<TransactionBLModel> GetTransactions()
        {
            var transactions = _transactionRepository.GetTransactions();
            return _mapper.Map<IEnumerable<TransactionBLModel>>(transactions);
        }
    }
}