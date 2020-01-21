using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRental.Models;

namespace VideoRental.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private VRDbContext _context;
        public CustomersController()
        {
            _context = new VRDbContext();
        }

        //Get /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        //Get /api/customers/id
        public Customer GetCstomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }
        //post /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
/*            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }*/
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        [HttpPut]
         public void UpdateCustomer(int id,Customer customer)
        {
/*            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }*/
            
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            customerInDb.IsScubscribedToNewsletter = customer.IsScubscribedToNewsletter;
            customerInDb.MembershipType = customer.MembershipType;
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            _context.SaveChanges();

        }
        //Delete  /api/custome/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }
    }
}
