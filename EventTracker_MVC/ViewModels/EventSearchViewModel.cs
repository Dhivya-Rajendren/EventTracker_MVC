using EventTracker_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventTracker_MVC.ViewModels
{
    public class EventSearchViewModel
    {
        public List<Event> Events { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
    }
}
