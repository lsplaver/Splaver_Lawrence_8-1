using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripsLog.Models;
using Microsoft.EntityFrameworkCore;

namespace TripsLog.Controllers
{
    public class TripController : Controller
    {
        private TripsContext context;

        public TripController(TripsContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index");
        }

        [Route("/[controller]/[action]")]
        [HttpGet]
        public IActionResult Add()
        {
            Trip trip = new Trip();
            ViewBag.Action = "Add";
            TempData.Clear();
            return View("Page1", trip);
        }

        [Route("/[controller]/[action]/page{id}")]
        // [HttpGet]
        public IActionResult Add(int id, Trip trip)
        {
            // string strAction = "";
            // switch((int)TempData["CurrentPage"])
            // {
            // case 1:
            if ((int)TempData["CurrentPage"] == 1)
            {
                TempData["Destination"] = trip.Destination;
                TempData["Accommodation"] = trip.Accommodation;
                TempData["StartDate"] = trip.StartDate;
                TempData["EndDate"] = trip.EndDate;
                // ViewBag.Action = "Add";
                if (TempData.Peek("Accommodation") != null)
                {
                    return View("Page2" /*, trip */);
                }
                else
                {
                    return View("Page3" /*, trip */);
                }
            }
            // strAction = "AddPage1";
            // break;
            // case 2:
            else if ((int)TempData["CurrentPage"] == 2)
            {
                TempData["AccommodationPhone"] = trip.AccommodationPhone;
                TempData["AccommodationEmail"] = trip.AccommodationEmail;
                return View("Page3" /*, trip */);
            }
            // strAction = "AddPage2";
            // break;
            // case 3:
            else
            {
                trip.Destination = (string)TempData["Destination"];
                trip.Accommodation = (string)TempData.Peek("Accommodation");
                trip.StartDate = (DateTime)TempData["StartDate"];
                trip.EndDate = (DateTime)TempData["EndDate"];
                trip.AccommodationPhone = (string)TempData["AccommodationPhone"];
                trip.AccommodationEmail = (string)TempData["AccommodationEmail"];
                context.Trips.Add(trip);
                context.SaveChanges();
                TempData["UserMessage"] = "Trip to " + TempData["Destination"] + " added.";
                return RedirectToAction("Index", "Home");
            }
                    // strAction = "AddPage3";
                    // break;
                    // default:
                    // strAction = "AddNew";
                    // break;
            }
            // return RedirectToAction(strAction, trip);
        }

        /* [HttpPost]
        public IActionResult AddPage1(int PageId, Trip trip)
        //
            TempData["Destination"] = trip.Destination;
            TempData["Accommodation"] = trip.Accommodation;
            TempData["StartDate"] = trip.StartDate;
            TempData["EndDate"] = trip.EndDate;
            // ViewBag.Action = "Add";
            if (TempData.Peek("Accommodation") != null)
            {
                return View("Page2" /*, trip */ /* );
            }
            else
            {
                return View("Page3", trip);
            }
        } */

        /* [HttpPost]
        public IActionResult AddPage2(Trip trip)
        {
            TempData["AccommodationPhone"] = trip.AccommodationPhone;
            TempData["AccommodationEmail"] = trip.AccommodationEmail;
            return View("Page3", trip);
        } */ 

        /* [HttpPost]
        public IActionResult AddPage3(Trip trip)
        {
            trip.Destination = (string)TempData["Destination"];
            trip.Accommodation = (string)TempData.Peek("Accommodation");
            trip.StartDate = (DateTime)TempData["StartDate"];
            trip.EndDate = (DateTime)TempData["EndDate"];
            trip.AccommodationPhone = (string)TempData["AccommodationPhone"];
            trip.AccommodationEmail = (string)TempData["AccommodationEmail"];
            context.Trips.Add(trip);
            context.SaveChanges();
            TempData["UserMessage"] = "Trip to " + TempData["Destination"] + " added.";
            return RedirectToAction("Index", "Home");
        } */
    }
// }
