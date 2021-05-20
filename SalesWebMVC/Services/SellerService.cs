using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public Seller FindById(int id) => _dbContext.Seller.Include(obj => obj.Department).SingleOrDefault(s => s.Id == id);

        public void Remove(int id)
        {
            var obj = _dbContext.Seller.Find(id);
            _dbContext.Seller.Remove(obj);
            _dbContext.SaveChanges();
        }
    }
}
