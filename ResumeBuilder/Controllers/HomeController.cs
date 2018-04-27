using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Microsoft.AspNetCore.Cors;
using ResumeBuilder.Models;

namespace ResumeBuilder.Controllers
{
	[EnableCors("*")] // tune to your needs
	[RoutePrefix("")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View();
        }

		[HttpPost]
		public JsonResult Create(List<string> data)
        {
            var temp = System.Convert.FromBase64String(data[0]);
            var htmlString = System.Text.ASCIIEncoding.ASCII.GetString(temp);
            string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            System.IO.File.WriteAllText(@roaming + "/file.html", htmlString);
			return Json(data);
		}
    }
}
