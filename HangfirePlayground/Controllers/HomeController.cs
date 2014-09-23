using Hangfire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HangfirePlayground.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult FireAndForget()
        {
            BackgroundJob.Enqueue(() => Debug.WriteLine("Fire-and-forget"));
            return Redirect("/hangfire/");
        }
        public ActionResult Delayed()
        {
            BackgroundJob.Schedule(() => Debug.WriteLine("Delayed"), TimeSpan.FromDays(1));
            return Redirect("/hangfire/");
        }
        public ActionResult Recurring()
        {
            RecurringJob.AddOrUpdate(() => Debug.Write("Recurring"), Cron.Minutely);
            return Redirect("/hangfire/");
        }
    }
}