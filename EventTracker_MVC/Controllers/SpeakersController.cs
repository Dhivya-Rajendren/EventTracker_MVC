using EventTracker_MVC.Models;
using EventTracker_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EventTracker_MVC.Controllers
{
    public class SpeakersController : Controller
    {
        List<Speaker> speakers = new List<Speaker>()
        {
            new Speaker(){SpeakerId=1,SpeakerName="RamGopal",Skill=".Net",SpeakerImg="/images/Speaker1.jfif"},
            new Speaker(){SpeakerId=2,SpeakerName="Getha",Skill="Angular",SpeakerImg="/images/Speaker2.jfif"}
        };
        public IActionResult Index()
        {
            SpeakerViewModel viewModel = new SpeakerViewModel();
            viewModel.PageTitle = "Speaker List";
            viewModel.Speakers = speakers;
            return View(viewModel);
        }

        public IActionResult Details(string name)
        {
            var sp = speakers.SingleOrDefault(s => s.SpeakerName.Equals(name));
            return Json(sp);
        }
    }
}
