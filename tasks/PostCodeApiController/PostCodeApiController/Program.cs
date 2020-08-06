using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;

namespace PostCodeApiController
{
    public class Program
    {
        static List<Root> locations = new List<Root>();
        //public static Uri url = new Uri($"https://api.postcodes.io/postcodes/{postcode}");
       
        static void Main(string[] args)
        {
            //GetLocation();
            
           
        }
        
        public static bool ValidatePostcode(Uri url)
        {
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetStringAsync(url);
                Validate myDeserializedClass = JsonConvert.DeserializeObject<Validate>(data.Result);
                return myDeserializedClass.result;
                //Console.WriteLine(myDeserializedClass.result.country); 
            }
        }

        public static Root GetLocation(string postcode)
        {
            Uri url = new Uri($"https://api.postcodes.io/postcodes/{postcode}");
            
            
            using (var httpClient = new HttpClient())
            {            
                var data = httpClient.GetStringAsync(url);
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(data.Result);
                return myDeserializedClass;
                //Console.WriteLine(myDeserializedClass.result.country); 
            }
        }
    }

    public class Codes
    {
        public string admin_district { get; set; }
        public string admin_county { get; set; }
        public string admin_ward { get; set; }
        public string parish { get; set; }
        public string parliamentary_constituency { get; set; }
        public string ccg { get; set; }
        public string ccg_id { get; set; }
        public string ced { get; set; }
        public string nuts { get; set; }
    }

    public class Result
    {
        public string postcode { get; set; }
        public int quality { get; set; }
        public int eastings { get; set; }
        public int northings { get; set; }
        public string country { get; set; }
        public string nhs_ha { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public string european_electoral_region { get; set; }
        public string primary_care_trust { get; set; }
        public string region { get; set; }
        public string lsoa { get; set; }
        public string msoa { get; set; }
        public string incode { get; set; }
        public string outcode { get; set; }
        public string parliamentary_constituency { get; set; }
        public string admin_district { get; set; }
        public string parish { get; set; }
        public string admin_county { get; set; }
        public string admin_ward { get; set; }
        public string ced { get; set; }
        public string ccg { get; set; }
        public string nuts { get; set; }
        public Codes codes { get; set; }
    }

    public class Root
    {
        public int status { get; set; }
        public Result result { get; set; }
    }

    public class Validate
    {
        public int status { get; set; }
        public bool result { get; set; }
    }
}
