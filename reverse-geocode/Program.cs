using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace reverse_geocode
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient wc = new WebClient())
            {
                // reverse api endpoint
                string url = "https://map.ir/reverse";
                // essential headers
                wc.Headers.Add("x-api-key", "your-api-key");
                // set lat/lon of a desired point
                wc.QueryString.Add("lat", "35.7447352857711");
                wc.QueryString.Add("lon", "51.2297075935295");

                string output = "";

                try {
                    output = wc.DownloadString(url);
                } catch (WebException webException) {
                    // catch error
                    Console.WriteLine(webException.GetType().Name);
                    HttpWebResponse response = (HttpWebResponse)webException.Response;
                    Console.WriteLine(response.StatusCode == HttpStatusCode.BadRequest);
                }

                // console write output
                Response r = JsonConvert.DeserializeObject<Response>(output);
                Console.WriteLine(output);
                // sample of accessing response values
                Console.WriteLine(r.address);
                Console.WriteLine(r.geom.coordinates[0].ToString());
            }
        }
    }
}
