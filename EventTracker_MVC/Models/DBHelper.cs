using System.Data.SqlClient;
namespace EventTracker_MVC.Models
{
    public class DBHelper:IDBHelper
    {

        SqlConnection con;
        SqlCommand com;
            string conString;
        SqlDataReader reader;

        public DBHelper(string conString)
        {
            this.conString = conString;
            con = new SqlConnection(conString);
            con.Open();

        }

        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();
             com = new("Select * from Events", con);
             reader = com.ExecuteReader();
            while (reader.Read())
            {
                Event _event = new Event() { EventId = reader.GetInt32(0), EventName = reader.GetString(1), EventType = reader.GetString(2), EventDate = reader.GetString(3), EventImg = reader.GetString(4) };
                events.Add(_event);
            }
            reader.Close();
            return events;
        }

        public Event GetEventById(int id)
        {
            Event _event = new Event();
            com = new("Select * from Events where eventid="+id, con);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                _event = new Event() { EventId = reader.GetInt32(0), EventName = reader.GetString(1), EventType = reader.GetString(2), EventDate = reader.GetString(3), EventImg = reader.GetString(4) };

            }

            return _event;

        }


    }
}
