using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Marilees_Trip.Models
{
    public class QPX
    {
        public object PostToFlights(string url, QPXModel request)
        {
            string requestJson = JsonConvert.SerializeObject(request,
                 Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(url, content).Result;

                
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var serializer = new JavaScriptSerializer(); //just setting up serializer

                    //changing from a string to a json object
                    var jsonContent = serializer.Deserialize<object>(result);
                    return jsonContent; // returning an object
                }
                else
                {
                    //return "error";
                    return response.ReasonPhrase;
                }
            }
        }
        //qpx view model

        public class QPXModel
        {
            public Request request { get; set; }

            //based on QPX Model
            //{"request": {"slice": [{"origin": "CLE","destination": "SFO","date": "2015-12-28"}],
            // "passengers": {"adultCount": 1,"infantInLapCount": 0,"infantInSeatCount": 0,"childCount": 0,
            //"seniorCount": 0},
            //"solutions": 20,"refundable": false}}

        }
        public class Request
        {
            public string maxPrice { get; set; }
            public string saleCountry { get; set; }
            public List<Slice> slice { get; set; }
            public Passengers passengers { get; set; }
            public int? solutions { get; set; }
            public bool? refundable { get; set; }
        }
        public class Slice
        {
            public string origin { get; set; }
            public string destination { get; set; }
            public string date { get; set; }
            public string kind { get; set; }
            public int? maxStops { get; set; }
            public int? maxConnectionDuration { get; set; }
            public string preferredCabin { get; set; }
            public PermittedDepartureTime permittedDepartureTime { get; set; }
            public List<string> permittedCarrier { get; set; }
            public string alliance { get; set; }
            public List<string> prohibitedCarrier { get; set; }
        }
        public class PermittedDepartureTime
        {
            public string kind { get; set; }
            public string earliestTime { get; set; }
            public string latestTime { get; set; }
        }
        public class Passengers
        {
            public int? adultCount { get; set; }
            public int? infantInLapCount { get; set; }
            public int? infantInSeatCount { get; set; }
            public int? childCount { get; set; }
            public string kind { get; set; }
            public int? seniorCount { get; set; }
        }
    }
}
