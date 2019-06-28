using System.Collections.Generic;
using Newtonsoft.Json;

public class Response
{
    public List<Distance> distance;
    public List<Duration> duration;
    public Dictionary<string, MetaPoint> origins;
    public Dictionary<string, MetaPoint> destinations;

    public Response()
    {

    }

    public class Distance
    {
        public string origin_index;
        public string destination_index;
        public float distance;
        
        public Distance(string origin_index, string destination_index, float distance)
        {
            this.origin_index = origin_index;
            this.destination_index = destination_index;
            this.distance = distance;
        }
    }

    public class Duration
    {
        public string origin_index;
        public string destination_index;
        public float duration;

        public Duration(string origin_index, string destination_index, float duration)
        {
            this.origin_index = origin_index;
            this.destination_index = destination_index;
            this.duration = duration;
        }
    }

    public class MetaPoint
    {
        public string name;
        public string county_name;
        public string district_title;
        public string ruraldistrict_title;
        public string suburb_title;
        public string neighbourhood_title;

        public MetaPoint(string name, string county_name, string district_title, string ruraldistrict_title, string suburb_title, string neighbourhood_title)
        {
            this.name = name;
            this.county_name = county_name;
            this.district_title = district_title;
            this.ruraldistrict_title = ruraldistrict_title;
            this.suburb_title = suburb_title;
            this.neighbourhood_title = neighbourhood_title;
        }
    }
}