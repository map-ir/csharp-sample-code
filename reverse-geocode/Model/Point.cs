using System.Collections.Generic;
public class Point
{
    public string type{get; set;}
    public List<double> coordinates;

    public Point(string type, List<double> coordinates)
    {
        this.type = type;
        this.coordinates = coordinates;
    }
}