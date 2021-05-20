using System.Collections.Generic;
using SalesWebMVC.Models;
using SalesWebMVC.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _dbContext;
        public DepartmentService(SalesWebMVCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Department>> FindAllAsync() => await _dbContext.Department.OrderBy(d => d.Name).ToListAsync();

    }
}
