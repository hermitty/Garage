using Garage.Application.JobManagement.Command;
using Garage.Application.JobManagement.Query;
using Garage.Application.UserManagement.Query;
using Garage.Website.Models;
using Garage.Website.Models.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage.Website.Controllers
{
    public class JobController : Controller
    {
        private readonly IMediator mediator;

        public JobController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: JobController
        public ActionResult Index(DateTime? date)
        {
            if (date == null) date = DateTime.Today;
            var request = new GetJobsWithDate()
            {
                Date = date
            };
            var result = mediator.Send(request).Result;
            var jobs = result.Select(j =>
                new Job()
                {
                    Id = j.Id,
                    Title = j.Title,
                    Status = j.Status,
                    AssigneeName = j.AssigneeName
                }
            );;
            var view = new JobListViewModel()
            {
                Date = (DateTime)date,
                Jobs = jobs.ToList()
            };
            return View(view);
        }

        // GET: JobController/Details/5
        public ActionResult Details(int id)
        {
            var getJob = new GetJob() { Id = id };
            var j = mediator.Send(getJob).Result;
            var job = new Job()
            {
                Id = j.Id,
                Title = j.Title,
                Status = j.Status,
                AssigneeName = j.AssigneeName,
                AssigneeId = j.AssigneeId,
                Description = j.Description,
                FinalDescription = j.FinalDescription,
                Scheduled = j.Scheduled,
                VehicleId = j.VehicleId
            };
            return View(job);
        }

        // GET: JobController/Create
        public ActionResult Create(int id)
        {
            var request = new GetWorkers();
            var response = mediator.Send(request).Result;
            var workers = response.Select(w =>
                new Worker()
                {
                    Id = w.Id,
                    Name = w.Name
                }).ToList();
            workers.Add(new Worker() { Id = 0, Name = ""});
            var job = new Job()
            {
                VehicleId = id,
                Scheduled = DateTime.Today
            };
            var view = new JobAddEditViewModel()
            {
                Workers = workers,
                Job = job
            };
            return View(view);
        }

        // POST: JobController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Job job)
        {
            try
            {
                var request = new AddJob()
                {
                    Title = job.Title,
                    VehicleId = job.VehicleId,
                    AssigneeId = job.AssigneeId,
                    Scheduled = job.Scheduled,
                    Status = "Created",
                    Description = job.Description
                };
                mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(job.VehicleId);
            }
        }

        // GET: JobController/Edit/5
        public ActionResult Edit(int id)
        {
            var request = new GetWorkers();
            var response = mediator.Send(request).Result;
            var workers = response.Select(w =>
                new Worker()
                {
                    Id = w.Id,
                    Name = w.Name
                }).ToList();

            var getJob = new GetJob() { Id = id };
            var j = mediator.Send(getJob).Result;
            var job = new Job()
            {
                Id = j.Id,
                Title = j.Title,
                Status = j.Status,
                AssigneeName = j.AssigneeName,
                AssigneeId = j.AssigneeId,
                Description = j.Description,
                FinalDescription = j.FinalDescription,
                Scheduled = j.Scheduled,
                VehicleId = j.VehicleId          
            };
            var status = new List<string>() { "Created", "InProgress", "Finished", "Canceled" };
            var view = new JobAddEditViewModel()
            {
                Workers = workers,
                Job = job,
                Status = status
            };
            return View(view);
        }

        // POST: JobController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobAddEditViewModel vm)
        {
            try
            {
                var j = vm.Job;
                var request = new EditJob()
                {
                    Id = j.Id,
                    Title = j.Title,
                    Status = j.Status,
                    AssigneeId = j.AssigneeId,
                    Description = j.Description,
                    FinalDescription = j.FinalDescription,
                    Scheduled = j.Scheduled,
                    VehicleId = j.VehicleId
                };
                mediator.Send(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobController/Delete/5

    }
}
