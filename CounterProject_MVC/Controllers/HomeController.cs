using CounterProject_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CounterProject_MVC.Controllers
{
    public class HomeController : Controller
    {
        #region Constructors
        public HomeController()
        {

        }
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.NumberOfClick = NumberOfClick;
            return View();
        }

        [HttpPost]
        public int UpdateCounter()
        {
            int defaultCounter = 1;
            try
            {
                using (var context = new CounterContext())
                {
                    if (context.Counters.Count() == 0)
                    {
                        // Add new counter if no exist
                        context.Counters.Add(new Counter { ClickCount = defaultCounter });
                    }
                    else
                    {
                        //update counter if exist
                        var counter = context.Counters.First();
                        if (counter.ClickCount >= 10)
                            return counter.ClickCount;
                        counter.ClickCount = counter.ClickCount + defaultCounter;
                    }
                    context.SaveChanges();

                 // return number of click
                  return context.Counters.First().ClickCount;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
        #endregion

        #region Public Methods
        private int NumberOfClick
        {
            get
            {
                using (var context = new CounterContext())
                {

                    if (context.Counters.Count() > 0)
                    {
                        return context.Counters.First().ClickCount;
                    }
                }
                return 0;
            }

        }


        #endregion
    }
}