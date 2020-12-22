using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDB _context;
        public CustomerController()
        {
            _context = new ApplicationDB();
        }
        // GET: Customer

        public ActionResult CustomerDetailsPage(int id)
        {
            Customer customer = _context.Customers.Include(c => c.MembershipType).First(c => c.Id == id);

            return View(customer);
        }

        public ActionResult Index()
        {
            return View("Customers");
        }

        public ActionResult New()
        {
            List<MembershipType> membershipTypes = _context.MembershipTypes.ToList();
            EditCustomerViewModel viewModel = new EditCustomerViewModel() { MembershipTypes = membershipTypes, Customer = new Customer() };
            return View("Edit",viewModel);
        }

        [HttpPost]
        public ActionResult Save(EditCustomerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                EditCustomerViewModel newCustomerViewModel = new EditCustomerViewModel
                {
                    Customer = viewModel.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };

                return View("Edit", newCustomerViewModel);
            }

            if (viewModel.Customer.Id == 0)
            {
                _context.Customers.Add(viewModel.Customer);
                _context.SaveChanges();
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);
                customerInDb.Name = viewModel.Customer.Name;
                customerInDb.BirthDate = viewModel.Customer.BirthDate;
                customerInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = viewModel.Customer.IsSubscribedToNewsLetter;
                _context.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var ViewModel = new EditCustomerViewModel
            {
                Customer = customer ?? new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("Edit", ViewModel);
        }
    }
}