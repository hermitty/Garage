using Garage.Website.Models;
using Hanssens.Net;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Garage.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        //public ActionResult Authorize()
        //{
        //    return View(new Credentials());
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Authorize(Credentials auth)
        //{
        //    try
        //    {
        //        var values = new Dictionary<string, string>
        //        {
        //            { "Login", auth.Login },
        //            { "Password", auth.Password }
        //        };
        //        var client = new HttpClient();

        //        var content = JsonConvert.SerializeObject(values);
        //       // var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

        //        var address = "https://localhost:5001/api/User/Authorize";
        //        var response = client.PostAsync(address, new StringContent(content, Encoding.UTF8, "application/json")).Result;

        //        //var response = client.PostAsync(address, content).Result;
        //        var responseString = response.Content.ReadAsStringAsync().Result;
        //        //cookie.Expires = DateTime.Now.AddDays(1);
        //        var token = JsonConvert.DeserializeObject(responseString);
                

        //        var cookie2 = new CookieOptions()
        //        {
        //            HttpOnly = true,
        //        };
        //        Response.Cookies.Append("token", responseString, cookie2);

        //        //Response.Cookies.GetType
        //        using (var storage = new LocalStorage())
        //        {
        //            storage.Store("token", responseString);
        //        }

        //            return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
