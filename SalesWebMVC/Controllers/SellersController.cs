using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using System.Collections.Generic;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            return View(_sellerService.FindAll());
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null) return NotFound();

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) return NotFound();

            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) return NotFound();

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var obj = _sellerService.FindById(id.Value);
            if (obj == null) return NotFound();

            ICollection<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Departments = departments, Seller = obj };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id) return BadRequest();
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
