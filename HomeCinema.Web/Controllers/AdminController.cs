using HomeCinema.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeCinema.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            ViewBag.Message = "Welcome to Admin Page";

            return View();
        }
    }
}