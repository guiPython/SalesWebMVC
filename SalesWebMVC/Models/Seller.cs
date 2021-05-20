using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public ICollection<SaleRecord> Sales { get; set; } = new HashSet<SaleRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, Department department, DateTime birthDate, double baseSalary)
        {
            Id = id;
            Name = name;
            Email = email;
            Department = department;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
        }

        public void AddSales(SaleRecord sr) => Sales.Add(sr);
        public void RemoveSales(SaleRecord sr) => Sales.Remove(sr);

        public double TotalSales(DateTime init, DateTime limit)
        {
            return Sales.Where(s => s.Date >= init && s.Date <= limit).Select(s => s.Amount).DefaultIfEmpty(0.0).Sum();
        }
    }
}
