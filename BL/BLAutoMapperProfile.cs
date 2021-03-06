﻿using AutoMapper;
using BL.BLModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLAutoMapperProfile : Profile
    {
        public BLAutoMapperProfile()
        {
            CreateMap<Category, CategoryBLModel>();
            CreateMap<Category, CategoryBLModel>().ReverseMap();

            CreateMap<Transaction, TransactionBLModel>();
            CreateMap<Transaction, TransactionBLModel>().ReverseMap();
        }
    }
}
