﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task< IActionResult> Index()
        {
            using var httpClient = new HttpClient();
         var responsmessage=   await httpClient.GetAsync("http://localhost:63884/api/categories");

            var JsonString = await responsmessage.Content.ReadAsStringAsync();
          var categories=  JsonConvert.DeserializeObject<List<Category>>(JsonString);

            return View(categories);
        }

        public IActionResult Privacy()
        {
            return View();
        }



        public IActionResult Create()
        {
            
           


            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Category category)
        {
            using var httpClient = new HttpClient();
         var JsonCategory=   JsonConvert.SerializeObject(category);
            StringContent content = new StringContent(JsonCategory,Encoding.UTF8,"application/json");
       var responceMessage=    await httpClient.PostAsync("http://localhost:63884/api/categories", content);

            if (responceMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("","bir sorun oluştu");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }



    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
