﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Core.Model;
using Newtonsoft.Json;

namespace WebClient.Controllers
{
    public class TaxGroupController : Controller
    {
        private readonly HttpClient _client;

        public TaxGroupController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:64007/TaxGroup/");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(TaxGroup taxGroup)
        {
            return await _client.PostAsJsonAsync("Create", taxGroup);
        }
    }
}