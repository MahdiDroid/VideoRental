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
            //
            var customers = _context.Customers.Include(c => c.MembershipType ).ToList();

            //var vm = new RandomMovieViewModel
            //{
            //    Customers = customers,
            //    Movie = new Movie { Id = 2, Name= "final destination"}
            //};

            return View(customers);
        }
        public ActionResult New()
        {
            return Content("new");
        }
        public ActionResult Details(int id)
        {
            var singleCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
 
            return View(singleCustomer);
        }
    }
}