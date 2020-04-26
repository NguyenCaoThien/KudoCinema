using KudoCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace KudoCinema.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using(var context = new ApplicationDbContext())
            {
                var customers = context.Customers.Include(p => p.MembershipType).ToList();

                return View(customers);
            }

        }
    }
}