using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Application.CustomerManagement.Command;
using Garage.Application.CustomerManagement.Query;
using Garage.Website.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Garage.Website.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public ActionResult Index()
        {
            var request = new GetAllCustomers();
            var response = mediator.Send(request).Result;
            var customers = response.Select(c =>
            new Customer()
            {
                Id = c.Id,
                Name = c.Name,
                Surname = c.Surname,
                EmailAddress = c.EmailAddress,
                TelephoneNumber = c.TelephoneNumber
            });

            return View(customers);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View(new Customer());
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer c)
        {
            try
            {
                var request = new AddCustomer()
                {
                    Name = c.Name,
                    Surname = c.Surname,
                    EmailAddress = c.EmailAddress,
                    TelephoneNumber = c.TelephoneNumber
                };
                mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var request = new GetCustomer()
            {
                Id = id
            };
            var response = mediator.Send(request).Result;
            var customer = new Customer()
            {
                Id = response.Id,
                Name = response?.Name,
                Surname = response?.Surname,
                EmailAddress = response?.EmailAddress,
                TelephoneNumber = response?.TelephoneNumber
            };
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer c)
        {
            try
            {
                var request = new EditCustomer()
                {
                    Id = c.Id,
                    Name = c?.Name,
                    Surname = c?.Surname,
                    EmailAddress = c?.EmailAddress,
                    TelephoneNumber = c?.TelephoneNumber
                };
                mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var request = new GetCustomer()
            {
                Id = id
            };
            var response = mediator.Send(request).Result;
            var customer = new Customer()
            {
                Id = response.Id,
                Name = response?.Name,
                Surname = response?.Surname,
                EmailAddress = response?.EmailAddress,
                TelephoneNumber = response?.TelephoneNumber
            };
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customer c)
        {
            try
            {
                var request = new DeleteCustomer()
                {
                    Id = c.Id
                };
                mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
