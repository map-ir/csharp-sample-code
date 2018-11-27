using System.Collections.Generic;
using Newtonsoft.Json;
public class Response
{
    [JsonProperty("odata.count")]
    public int count;
    public List<Value> value;

    public class Value {
        public string Text;
        public string Title;
        public string Address;
        public string Province;
        public string City;
        public string Type;
        public string FClass;
        public Coordinate Coordinate;

        public Value(string text, string title, string address,
             string province, string city, string type, string fclass, Coordinate coordinate)
        {
            this.Text = text;
            this.Title = title;
            this.Address = address;
            this.Province = province;
            this.City = city;
            this.Type = type;
            this.FClass = fclass;
            this.Coordinate = coordinate;
        }
    }

    public class Coordinate {
        public double lat;
        public double lon;

        public Coordinate(double lat, double lon)
        {
            this.lat = lat;
            this.lon = lon;
        }
    }
}