using CourseWork2.Models;

using CourseWork2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupCoursework.Controllers
{
    [Authorize(Roles = "Manager,Assistant")]
    public class DashboardController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Dashboard
        public ActionResult Index()
        {

            //ViewData["Id"] = context.Users.Count();

            return View();
        }

    }
}