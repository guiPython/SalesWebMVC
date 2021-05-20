using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

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

        public void Update(Seller seller)
        {
            if (!_dbContext.Seller.Any(s => s.Id == seller.Id)) throw new NotFoundException("Id not Found");
            try
            {
                _dbContext.Update(seller);
                _dbContext.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
