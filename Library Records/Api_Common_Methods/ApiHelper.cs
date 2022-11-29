using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Library_Records.Api_Common_Methods
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost/ShopfyApi/")
                //BaseAddress = new Uri("https://localhost:44374/")
            };

            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
