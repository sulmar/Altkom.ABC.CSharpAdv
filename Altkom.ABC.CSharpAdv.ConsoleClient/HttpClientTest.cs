using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{

    class HttpClientTest
    {
        public static void Test()
        {

            Task.Run(()=>GetCustomersTest());

            Console.ReadKey();
        }

        private static async Task GetCustomersTest()
        {
            string baseUri = "http://localhost:51856";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);
                HttpResponseMessage response = await client.GetAsync("api/customers");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    // Install-Package Microsoft.AspNet.WebApi.Client
                    var customers = await response.Content.ReadAsAsync<IEnumerable<Customer>>();
                }


            }
        }
    }
}
