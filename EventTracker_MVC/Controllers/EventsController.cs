using Microsoft.AspNetCore.Mvc;
using EventTracker_MVC.Models;
using System.Linq;
using EventTracker_MVC.ViewModels;
using System.Collections.Generic;

namespace EventTracker_MVC.Controllers
{
    public class EventsController : Controller
    {
        string conString;
        IConfiguration _configuration;

        IDBHelper _dbHelper;

        //DI using constructors
        public EventsController(IConfiguration configuration,IDBHelper dBHelper)
        {
            _configuration = configuration;
            conString = _configuration.GetConnectionString("EventDB");
            dBHelper = new DBHelper(conString);
            this._dbHelper = dBHelper;

        }
        public IActionResult Index()
        {

            ViewBag.Title = "Welcome To Event Tracker! ! !";

            TempData["Heading"] = "Events List";
          
            return View(_dbHelper.GetEvents());
        }
      
        public IActionResult Details(int id)
        {
                  
            var _event = _dbHelper.GetEvents().SingleOrDefault(t => t.EventId == id);

            return View(_event);
        }
        public IActionResult GetDataFromIndex()
        {
            string heading = (string)TempData["Heading"];

            TempData["_Heading"] = heading;

            return View();
        }
        public IActionResult CreateEvent()
        {
            ViewBag.Message = null;
            return View();
        }

        [HttpPost]
        public IActionResult CreateEvent(Event _event)
        {

            ViewBag.Message = _event.EventName + "------" + _event.EventType;
            return View();
        }

    }
}
