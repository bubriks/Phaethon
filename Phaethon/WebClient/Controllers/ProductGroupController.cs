﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Core.Model;

namespace WebClient.Controllers
{
    public class ProductGroupController : Controller
    {
        private readonly HttpClient _client;

        public ProductGroupController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:64010/Api/ProductGroup/");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductGroup productGroup)
        {
            await _client.PostAsJsonAsync("Create", productGroup);
            return RedirectToAction("Create");
        }
    }
}