using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        [Display(Name = "Birth Date")] 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DataType(DataType.Currency)]
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
