using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using VideoRental.Models;
using VideoRental.ViewModels;

namespace VideoRental.Controllers
{
    public class CustomerController : Controller
    {
        private VRDbContext _context;
        public CustomerController()
        {
            _context = new VRDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            
            var customers = _context.Customers.Include(c => c.MembershipType ).ToList();


            return View(customers);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes;
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            
/*            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("New", viewModel);
            }*/


            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.IsScubscribedToNewsletter = customer.IsScubscribedToNewsletter;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.Birthdate = customer.Birthdate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index","Customer");
        }
        public ActionResult Edit (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
             if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New", viewModel);
        }
     
        public ActionResult Delete(int id)
        { 
            var CustomerForDelete = _context.Customers.SingleOrDefault(c => c.Id == id);
            _context.Customers.Remove(CustomerForDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var singleCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
 
            return View(singleCustomer);
        }
    }
}