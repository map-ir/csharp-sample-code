using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace distance_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient wc = new WebClient())
            {
                // search api endpoint
                string url = "https://dev.map.ir/distancematrix";
                // essential headers
                wc.Headers.Add("x-api-key", "your-api-key");

                Points origins = new Points();
                origins.addPoint("origin_1", 35.704965, 51.355551);

                Points destinations = new Points();
                destinations.addPoint("destination_1", 35.706826, 51.347341);

                wc.QueryString.Add("origins", origins.toString());
                wc.QueryString.Add("destinations", destinations.toString());
                wc.QueryString.Add("$sorted", "true");
                // $filter is optional. if use this it can be following items:
                //  
                wc.QueryString.Add("$filter", "");
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
                // Console.WriteLine(output);
                // Console.WriteLine(r.origins.TryGetValue("origin_1"));
                MetaPoint result;
                Dictionary<string, MetaPoint> dict = (Dictionary<string, MetaPoint>)r.origins;

                if(dict.TryGetValue("origin_1", out result)) {
			        Console.WriteLine(result.name);
		        } else {
			        Console.WriteLine("Could not find the specified key.");
		        }
            }
        }
    }
}
