using System;
using System.Collections.Generic;
using SalesWebMVC.Models;
using SalesWebMVC.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _dbContext;
        public DepartmentService(SalesWebMVCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Department> FindAll() => _dbContext.Department.OrderBy(d => d.Name).ToList();

    }
}
