﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XH.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Js test
        /// </summary>
        /// <returns></returns>
        public ActionResult JsTest()
        {
            Session["test"] = 1234;
            return View();
        }

        /// <summary>
        /// Gallery
        /// </summary>
        /// <returns></returns>
        public ActionResult Gallery()
        {
            return View();
        }
    }
}