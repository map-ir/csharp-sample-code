using System.Collections.Generic;
using System;

public class Points
{
    public List<Point> data;
    public string response;
    public Points()
    {
        data = new List<Point>();
    }

    public void addPoint(string id, double lat, double lon)
    {
        data.Add(new Point(id, lat, lon));
    }

    public override string ToString()
    {
        for (var i = 0; i < data.Count; i++)
        {
            Point item = (Point) data[i];
            response += item.id + ',' + item.lat + ',' + item.lon;
            if (i < data.Count-1) {
                response += '|';
            }
        }

        return response;
    }

    public class Point
    {
        public string id;
        public double lat;
        public double lon;

        public Point(string id, double lat, double lon)
        {
            this.id = id;
            this.lat = lat;
            this.lon = lon;
        }

    }
}