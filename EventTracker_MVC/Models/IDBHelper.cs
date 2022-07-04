namespace EventTracker_MVC.Models
{
    public interface IDBHelper
    {
        List<Event> GetEvents();

        Event GetEventById(int id);

    }
}
