using AutoMapper;
using KudoCinema.App_Start;
using KudoCinema.Dtos;
using KudoCinema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KudoCinema.Controllers.Api
{
    public class CustomerController : ApiController
    {

        private readonly IMapper mapper;

        public CustomerController()
        {
            mapper = AutoMapperConfig.Mapper;
        }

        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            using(var context = new ApplicationDbContext())
            {
                var customer = context.Customers.Include(p => p.MembershipType).FirstOrDefault(p => p.Id == id);
                if(customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllCustomers()
        {
            using(var context= new ApplicationDbContext())
            {
                var customers = context.Customers.Include(p => p.MembershipType).ToList();
                if(customers == null)
                {
                    return NotFound();
                }

                return Ok(customers);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            using(var context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var customer = mapper.Map<CustomerDto, Customer>(customerDto);
                context.Customers.Add(customer);
                context.SaveChanges();

                customerDto.Id = customer.Id;
                return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(CustomerDto customerDto)
        {
            using(var context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var updatedCustomer = context.Customers.FirstOrDefault(p => p.Id == customerDto.Id);

                if(updatedCustomer == null)
                {
                    return NotFound();
                }

                mapper.Map(customerDto, updatedCustomer);                

                context.SaveChanges();

                return Ok();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            using(var context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var customer = context.Customers.FirstOrDefault(p => p.Id == id);
                if(customer == null)
                {
                    return NotFound();
                }

                context.Customers.Remove(customer);
                context.SaveChanges();

                return Ok();
            }
        }
    }
}
