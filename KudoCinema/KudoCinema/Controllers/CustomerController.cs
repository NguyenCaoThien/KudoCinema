using KudoCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using KudoCinema.ViewModels;

namespace KudoCinema.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                return View();
            }
        }

        public ActionResult New()
        {
            using(var context = new ApplicationDbContext())
            {
                var membershipTypes = context.MembershipTypes.ToList();

                var viewModel = new CustomerFormViewModel()
                {
                    MembershipTypes = membershipTypes,
                    Customer = new Customer()
                };

                ViewBag.FormTitle = "Add new customer";
                return View("CustomerForm", viewModel);
            }
        }

        [Route("Customer/Save")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            using(var context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    var membershipTypes = context.MembershipTypes.ToList();
                    var viewModel = new CustomerFormViewModel()
                    {
                        MembershipTypes = membershipTypes,
                        Customer = customer
                    };

                    return View("CustomerForm", viewModel);
                }
                else if(customer.Id == 0)
                {
                    context.Customers.Add(customer);
                }
                else
                {
                    var updatedCustomer = new Customer();
                    updatedCustomer.Id = customer.Id;
                    updatedCustomer.Name = customer.Name;
                    updatedCustomer.IsSubcribed = customer.IsSubcribed;
                    updatedCustomer.PhoneNumber = customer.PhoneNumber;
                    updatedCustomer.MembershipTypeId = customer.MembershipTypeId;
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
        }

        [Route("Customer/Edit/id")]
        public ActionResult Edit(int id)
        {
            using(var context = new ApplicationDbContext())
            {
                var membershipTypes = context.MembershipTypes.ToList();
                var customer = context.Customers.FirstOrDefault(p => p.Id == id);

                var viewModel = new CustomerFormViewModel()
                {
                    MembershipTypes = membershipTypes,
                    Customer = customer
                };

                ViewBag.FormTitle = "Edit customer";
                return View("CustomerForm", viewModel);
            };
        }

        [Route("Customers/Details/id")]
        public ActionResult Details(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var customers = context.Customers.Include(p => p.MembershipType).FirstOrDefault(p => p.Id == id);

                return View("Detail", customers);
            }
        }
    }
}