using SalesWebMVC.Data;
using SalesWebMVC.Models;
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

        public async Task<List<Seller>> FindAllAsync() => await _dbContext.Seller.ToListAsync();

        public async Task InsertAsync(Seller obj)
        {
            _dbContext.Add(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id) => await _dbContext.Seller.Include(obj => obj.Department).SingleOrDefaultAsync(s => s.Id == id);

        public async Task RemoveAsync(int id)
        {
            var obj = await _dbContext.Seller.FindAsync(id);
            _dbContext.Seller.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller seller)
        {
            if (!(await _dbContext.Seller.AnyAsync(s => s.Id == seller.Id))) throw new NotFoundException("Id not Found");
            try
            {
                _dbContext.Update(seller);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
