using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMVCContext _dbContext;

        public SalesRecordService(SalesWebMVCContext dbContext)
        {
            _dbContext = dbContext;       
        }

        public async Task<List<SaleRecord>> FindByDateAsync(DateTime? init, DateTime? final)
        {
            var result = from obj in _dbContext.SaleRecord select obj;

            if (init.HasValue) result = result.Where(s => s.Date >= init.Value);

            if (final.HasValue) result = result.Where(s => s.Date <= final.Value);

            return await result.Include(s => s.Seller).Include(s => s.Seller.Department).OrderByDescending(s => s.Date).ToListAsync();
        }

        public async Task<List<IGrouping<Department,SaleRecord>>> FindByDateGroupingAsync(DateTime? init, DateTime? final)
        {
            var result = from obj in _dbContext.SaleRecord select obj;

            if (init.HasValue) result = result.Where(s => s.Date >= init.Value);

            if (final.HasValue) result = result.Where(s => s.Date <= final.Value);

            var data = await result
                .Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .OrderByDescending(s => s.Date)
                .ToListAsync();

            return data.GroupBy(s => s.Seller.Department).ToList();
        }
    }
}
