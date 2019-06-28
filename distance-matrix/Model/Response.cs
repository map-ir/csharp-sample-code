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
}