using Garage.Application.CustomerManagement.Command;
using Garage.Application.CustomerManagement.Query;
using Garage.Website.Models;
using Garage.Website.Models.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Garage.Website.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IMediator mediator;

        public VehicleController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public ActionResult Index(int id)
        {
            var request = new GetVehiclesForCustomer()
            {
                CustomerId = id
            };
            var response = mediator.Send(request).Result;
            var vehicles = response.Select(v =>
            new Vehicle()
            {
                Id = v.Id,
                Brand = v?.Brand,
                LicenseNumber = v?.LicenseNumber,
                OwnerId = v.OwnerId,
                Type = v?.Type

            });
            var view = new VehicleListViewModel()
            {
                OwnerId = id,
                Vehicle = vehicles
            };
            return View(view);
        }

        public ActionResult Create(int ownerId)
        {
            var newVehicle = new Vehicle()
            {
                OwnerId = ownerId
            };
            return View(newVehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle v)
        {
            try
            {
                var request = new AddVehicleForCustomer()
                {
                    Brand = v?.Brand,
                    LicenseNumber = v?.LicenseNumber,
                    OwnerId = v.OwnerId,
                    Type = v?.Type
                };
                mediator.Send(request);
                return RedirectToAction(nameof(Index), new { id = v.OwnerId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var request = new GetVehicle()
            {
                Id = id
            };
            var response = mediator.Send(request).Result;
            var vehicle = new Vehicle()
            {
                Id = response.Id,
                Brand = response?.Brand,
                LicenseNumber = response?.LicenseNumber,
                Type = response?.Type,
                OwnerId = response.OwnerId
            };
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehicle v)
        {
            try
            {
                var request = new EditVehicle()
                {
                    Id = v.Id,
                    Brand = v.Brand,
                    LicenseNumber = v.LicenseNumber,
                    OwnerId = v.OwnerId,
                    Type = v.Type
                };
                mediator.Send(request);
                return RedirectToAction(nameof(Index), new { id = v.OwnerId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var request = new GetVehicle()
            {
                Id = id
            };
            var response = mediator.Send(request).Result;
            var vehicle = new Vehicle()
            {
                Id = response.Id,
                Brand = response?.Brand,
                LicenseNumber = response?.LicenseNumber,
                Type = response?.Type,
                OwnerId = response.OwnerId
            };
            return View(vehicle);
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Vehicle vehicle)
        {
            try
            {
                var getVehicle = new GetVehicle()
                {
                    Id = vehicle.Id
                };
                var response = mediator.Send(getVehicle).Result;
                var request = new DeleteVehicle()
                {
                    Id = vehicle.Id
                };
                mediator.Send(request);
                return RedirectToAction(nameof(Index), new { id = response.OwnerId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var getVehicle = new GetVehicle()
            {
                Id = id
            };
            var vehicleResult = mediator.Send(getVehicle).Result;

            var vehicle = new Vehicle()
            {
                Id = vehicleResult.Id,
                Brand = vehicleResult?.Brand,
                LicenseNumber = vehicleResult?.LicenseNumber,
                Type = vehicleResult?.Type,
                OwnerId = vehicleResult.OwnerId
            };

            var getCustomer = new GetCustomer()
            {
                Id = vehicle.OwnerId
            };
            var ownerResult = mediator.Send(getCustomer).Result;
            var owner = new Customer()
            {
                Id = ownerResult.Id,
                Name = ownerResult.Name,
                Surname = ownerResult.Surname,
            };

            var view = new VehicleDetailsViewModel()
            {
                Vehicle = vehicle,
                Customer = owner
            };

            return View(view);
        }
    }
}
