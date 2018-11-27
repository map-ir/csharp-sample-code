﻿using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace search_service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient wc = new WebClient())
            {
                // search api endpoint
                string url = "https://map.ir/search";
                // essential headers
                wc.Headers.Add("x-api-key", "your-api-key");
                wc.Headers.Add("Content-Type", "application/json");
                // create request data object
                // set center what you want
                double center_lat = 31.55;
                double center_lon = 56.3;
                
                Point center = new Point("Point", new List<double>(){center_lon, center_lat});
                Request data = new Request("تهران", center);
                // post request to search api
                string request = JsonConvert.SerializeObject(data);
                string output = "";
                try {
                    output = wc.UploadString(url, JsonConvert.SerializeObject(data));
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
                Console.WriteLine(r.value[0].City);
                Console.WriteLine(r.count);
            }
        }
    }
}
