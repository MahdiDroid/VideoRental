using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRental.Dtos;
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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }
        //Get /api/customers/id
        public CustomerDto GetCstomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer,CustomerDto> (customer);
        }
        //post /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            /*            if (!ModelState.IsValid)
                        {
                            throw new HttpResponseException(HttpStatusCode.BadRequest);
                        }*/
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;
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
