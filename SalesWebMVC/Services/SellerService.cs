﻿using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class SellerService
    {

        private readonly SalesWebMVCContext _dbContext;
        public SellerService(SalesWebMVCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Seller> FindAll() => _dbContext.Seller.ToList();

        public void Insert(Seller obj)
        {
            _dbContext.Add(obj);
            _dbContext.SaveChanges();
        }
    }
}