using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Web;

namespace static_map
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient wc = new WebClient())
            {
                var builder = new UriBuilder("https://map.ir/static");
                builder.Port = -1;
                // static map api endpoint
                // essential headers
                wc.Headers.Add("x-api-key", "your-api-key");

                wc.QueryString.Add("width", "700");
                wc.QueryString.Add("height", "500");
                wc.QueryString.Add("zoom_level", "14");

                var query = HttpUtility.ParseQueryString(builder.Query);
                Markers markers = new Markers();
                markers.addMarker(Markers.COLOR_NAVYBLUE, 35.712580, 51.368895);
                markers.addMarker(Markers.COLOR_TEAL, 35.713580, 51.368895);

                query["width"] = "700";
                query["height"] = "500";
                query["zoom_level"] = "14";
                string queryString =
                 Program.concatQueryString(query.ToString(), markers.ToString());
                builder.Query = queryString;
                string url = builder.ToString();
                // Construct HTTP request to get the logo
                HttpWebRequest httpRequest = (HttpWebRequest)
                    WebRequest.Create(url);
                httpRequest.Method = WebRequestMethods.Http.Get;

                // Get back the HTTP response for web server
                HttpWebResponse httpResponse 
                    = (HttpWebResponse)httpRequest.GetResponse();
                Stream httpResponseStream = httpResponse.GetResponseStream();

                // Define buffer and buffer size
                int bufferSize = 1024;
                byte[] buffer = new byte[bufferSize];
                int bytesRead = 0;
                
                // Read from response and write to file
                FileStream fileStream = File.Create("map.png");
                while ((bytesRead = httpResponseStream.Read(buffer, 0, bufferSize)) != 0) 
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }
        }

        static string concatQueryString(string queryOne, string queryTwo)
        {
            return queryOne + "&" + queryTwo;
        }
    }
}
