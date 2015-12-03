﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jitter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // refers to the view '/Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            List<string> my_list_of_things = new List<string>();
            my_list_of_things.Add("Timmy");
            my_list_of_things.Add("Chef");
            my_list_of_things.Add("Greg");


            return View(my_list_of_things);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}