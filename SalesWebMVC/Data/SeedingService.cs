using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private readonly SalesWebMVCContext _dbContext;

        public SeedingService(SalesWebMVCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Department.Any() || _dbContext.Seller.Any() || _dbContext.SaleRecord.Any()) return;

            Department[] departments = 
            { 
                new Department(1, "Computer"),
                new Department(2, "Eletronics"),
                new Department(3, "Fashion"),
                new Department(4, "Books") 
            };

            Seller[] sellers =
            {
                new Seller(1,"Guilherme Rocha","gui@gmail.com",departments[0],new DateTime(2001,10,02),1200.00),
                new Seller(2,"Mario Games","mario@gmail.com",departments[1],new DateTime(1978,05,15),3000.00),
                new Seller(3,"Jorge Amado","jorge@gmail.com",departments[3],new DateTime(2002,08,24),2500.00),
                new Seller(4,"Paulo Maluco","maluquinho@gmail.com",departments[2],new DateTime(1999,03,07),4500.00),
                
            };


            SaleRecord[] saleRecords =
            {
                new SaleRecord(1, new DateTime(2018, 09, 25), 11000.0,SaleStatus.BILLED, sellers[0]),
                new SaleRecord(2, new DateTime(2018, 09, 4), 7000.0,SaleStatus.BILLED, sellers[0]),
                new SaleRecord(3, new DateTime(2018, 09, 13), 4000.0,SaleStatus.CANCELED, sellers[0]),
                new SaleRecord(4, new DateTime(2018, 09, 1), 8000.0,SaleStatus.BILLED, sellers[0]),
                new SaleRecord(5, new DateTime(2018, 09, 21), 3000.0,SaleStatus.BILLED, sellers[0]),
                new SaleRecord(6, new DateTime(2018, 09, 15), 2000.0,SaleStatus.BILLED, sellers[1]),
                new SaleRecord(7, new DateTime(2018, 09, 28), 13000.0,SaleStatus.BILLED, sellers[1]),
                new SaleRecord(8, new DateTime(2018, 09, 11), 4000.0,SaleStatus.BILLED, sellers[1]),
                new SaleRecord(9, new DateTime(2018, 09, 14), 11000.0,SaleStatus.PENDING, sellers[1]),
                new SaleRecord(10, new DateTime(2018, 09, 7), 9000.0,SaleStatus.BILLED, sellers[1]),
                new SaleRecord(11, new DateTime(2018, 09, 13), 6000.0,SaleStatus.BILLED, sellers[2]),
                new SaleRecord(12, new DateTime(2018, 09, 25), 7000.0,SaleStatus.PENDING, sellers[2]),
                new SaleRecord(13, new DateTime(2018, 09, 29), 10000.0,SaleStatus.BILLED, sellers[2]),
                new SaleRecord(14, new DateTime(2018, 09, 4), 3000.0,SaleStatus.BILLED, sellers[2]),
                new SaleRecord(15, new DateTime(2018, 09, 12), 4000.0,SaleStatus.BILLED, sellers[0]),
                new SaleRecord(16, new DateTime(2018, 10, 5), 2000.0,SaleStatus.BILLED, sellers[0]),
                new SaleRecord(17, new DateTime(2018, 10, 1), 12000.0,SaleStatus.BILLED, sellers[2]),
                new SaleRecord(18, new DateTime(2018, 10, 24), 6000.0,SaleStatus.BILLED, sellers[1]),
                new SaleRecord(19, new DateTime(2018, 10, 22), 8000.0,SaleStatus.BILLED, sellers[2]),
                new SaleRecord(20, new DateTime(2018, 10, 15), 8000.0,SaleStatus.BILLED, sellers[3]),
                new SaleRecord(21, new DateTime(2018, 10, 17), 9000.0,SaleStatus.BILLED, sellers[3]),
                new SaleRecord(22, new DateTime(2018, 10, 24), 4000.0,SaleStatus.BILLED, sellers[3]),
                new SaleRecord(23, new DateTime(2018, 10, 19), 11000.0,SaleStatus.CANCELED, sellers[2]),
                new SaleRecord(24, new DateTime(2018, 10, 12), 8000.0,SaleStatus.BILLED, sellers[1]),
                new SaleRecord(25, new DateTime(2018, 10, 31), 7000.0,SaleStatus.BILLED, sellers[1]),
                new SaleRecord(26, new DateTime(2018, 10, 6), 5000.0,SaleStatus.BILLED, sellers[2]),
                new SaleRecord(27, new DateTime(2018, 10, 13), 9000.0,SaleStatus.PENDING, sellers[3]),
                new SaleRecord(28, new DateTime(2018, 10, 7), 4000.0,SaleStatus.BILLED, sellers[2]),
                new SaleRecord(29, new DateTime(2018, 10, 23), 12000.0,SaleStatus.BILLED, sellers[0]),
                new SaleRecord(30, new DateTime(2018, 10, 12), 5000.0,SaleStatus.BILLED, sellers[1]),
            };

            _dbContext.AddRange(departments);
            _dbContext.AddRange(sellers);
            _dbContext.AddRange(saleRecords);

            _dbContext.SaveChanges();
        }
    }
}
