using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TripsLog.Models;

namespace TripsLog.Controllers
{
    public class HomeController : Controller
    {
        private TripsContext context;

        public HomeController(TripsContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index()
        {
            var trps = context.Trips.OrderBy(t => t.TripId).ToList();

            // List<Trip> trips;

            var model = new TripListViewModel
            {
                Trips = trps
            };

            return View(model);
        }

    }
}
