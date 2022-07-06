using Microsoft.AspNetCore.Mvc;
using EventTracker_MVC.Models;
using System.Linq;
using EventTracker_MVC.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace EventTracker_MVC.Controllers
{
 
    public class EventsController : Controller
    {
        string conString;
        IConfiguration _configuration;

        IDBHelper _dbHelper;

      

        //DI using constructors
        public EventsController(IConfiguration configuration)
        {
            _configuration = configuration;
            conString = _configuration.GetConnectionString("EventDB");
       
        }
        public IActionResult Index()
        {
          
            HttpContext.Session.SetString("UserName", "Dhivya");
            _dbHelper = new DBHelper(conString);
            ViewBag.Title = "Welcome To Event Tracker! ! !";

            TempData["Heading"] = "Events List";
          
            return View(_dbHelper.GetEvents());
        }
      
        public IActionResult Details(int id)
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            _dbHelper = new DBHelper(conString);

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
            _dbHelper = new DBHelper(conString);
            List<string> eventTypes = new List<string>() { "Live Course", "Conference", "Webinar", "Seminar" };

            List<SelectListItem> typeList = new List<SelectListItem>();
            for (int i = 0; i < eventTypes.Count; i++)
            {
                typeList.Add(new SelectListItem { Text = eventTypes[i], Value = eventTypes[i] });
            }


            ViewBag.EventTypes = (IEnumerable<SelectListItem>)typeList;
            ViewBag.Message = null;
            return View();
        }

        [HttpPost]
        public IActionResult CreateEvent(Event _event)
        {
            _dbHelper = new DBHelper(conString);

            _dbHelper.AddNewEvent(_event);

            ViewBag.Message = _event.EventName + "------" + _event.EventType;
            return View();
        }

    }
}
