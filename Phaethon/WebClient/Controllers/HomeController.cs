﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using a = WebClient.Resources.Language_Files.LanguagePack;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = a.AboutPageDescriptionText;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = a.YourContectPage;

            return View();
        }
    }
}