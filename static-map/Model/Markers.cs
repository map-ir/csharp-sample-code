using System.Collections.Generic;
using System;

public class Markers
{
    public const string COLOR_BLACK = "black";
    public const string COLOR_BLUE = "blue";
    public const string COLOR_GREEN = "green";
    public const string COLOR_MAGENTA = "magenta";
    public const string COLOR_NAVYBLUE = "navyblue";
    public const string COLOR_ORANGE = "orange";
    public const string COLOR_PINK = "pink";
    public const string COLOR_RED = "red";
    public const string COLOR_SKYBLUE = "skyblue";
    public const string COLOR_TEAL = "teal";
    public const string COLOR_WHITE = "white";
    public const string COLOR_YELLOW = "yellow";
    public List<Marker> data;
    public string response;
    public Markers()
    {
        data = new List<Marker>();
    }

    public void addMarker(string color, double lat, double lon, string label = null)
    {
        data.Add(new Marker(color, lat, lon, label));
    }

    public override string ToString()
    {
        for (var i = 0; i < data.Count; i++) {
            Marker item = (Marker) data[i];
            response += "markers=color:" + item.color;
            if (item.label != null) {
                response += "|label:" + item.label;
            }
            response += '|' + item.lon.ToString() + ',' + item.lat.ToString();
            if (i < data.Count-1) {
                response += '&';
            }
        }

        return response;
    }

    public class Marker
    {
        public string color;
        public double lat;
        public double lon;
        public string label;
        public Marker(string color, double lat, double lon, string label = null)
        {
            this.color = color;
            this.lat = lat;
            this.lon = lon;
            this.label = label;
        }
    }
}