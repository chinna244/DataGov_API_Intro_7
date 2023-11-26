using System.ComponentModel.DataAnnotations;

namespace DataGov_API_Intro_7.Models
{
    public class Parks
    {
        public int Id { get; set; }

        public string total { get; set; }
        public string limit { get; set; }
        public string start { get; set; }
        public List<Park> data { get; set; }
    }

    public class Park
    {
        public string id { get; set; }
        public string url { get; set; }
        public string fullName { get; set; }
        public string parkCode { get; set; }
        public string description { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string latLong { get; set; }

        public string states { get; set; }


        public string directionsInfo { get; set; }
        public string directionsUrl { get; set; }

        public string weatherInfo { get; set; }
        public string name { get; set; }
        public string designation { get; set; }
        public Parks Parks { get; set; }
    }
    public class Stations
    {
        [Key]
        public int station_id { get; set; }
        public string station_name { get; set; }
        public string? station_phone{ get; set; }
        public string? street_address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        public string? zip { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }
        public string? fuel_type_code { get; set; }
        public DateTime Date_Updated { get; set; }

    }
    public class root_object
    {
        public List<Stations> fuel_stations { get; set; }


    }
}
